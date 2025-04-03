using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrab : MonoBehaviour
{
    public Camera cam;
    [SerializeField] private float range = 3.0f;

    [SerializeField] private LayerMask itemLayer = 3;
    [SerializeField] private LayerMask interactableLayer = 3;
    [SerializeField] private LayerMask buttonLayer = 3;

    private InputSystem_Actions inputActions;
    private InputAction interactAction => inputActions.Player.Interact;
    private InputAction scrollAction => inputActions.Player.ScrollWheel;

    private float scrollDir;

    [SerializeField] private Transform objectGrabPointTransform;
    private Vector3 objectGrabPointBasePosition;
    private GrabableObject grabableObject;
    private Interactable interactable;
    private Button button;

    private void Awake()
    {
        objectGrabPointBasePosition = objectGrabPointTransform.localPosition;

        inputActions = new InputSystem_Actions();

        interactAction.performed += InteractAction_performed;
        scrollAction.performed += ScrollAction_performed;
        scrollAction.canceled += ScrollAction_canceled;
    }

    private void ScrollAction_canceled(InputAction.CallbackContext obj)
    {
        scrollDir = scrollAction.ReadValue<float>();
    }

    private void ScrollAction_performed(InputAction.CallbackContext obj)
    {
        scrollDir = scrollAction.ReadValue<float>();
    }

    private void InteractAction_performed(InputAction.CallbackContext obj)
    {
        Grab();
    }

    private void OnEnable()
    {
        interactAction.Enable();
        scrollAction.Enable();
    }

    private void OnDisable()
    {
        interactAction.Disable();
        scrollAction.Disable();
    }

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        objectGrabPointTransform.Translate(new Vector3(0f,0f, scrollDir * 10 * Time.deltaTime));
    }

    private void Grab()
    {
        var targ = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));

        if (grabableObject == null)
        {
            
            if (Physics.Raycast(targ, out RaycastHit raycastHitItem, range, itemLayer))
            {
                if (raycastHitItem.transform.TryGetComponent(out grabableObject))
                {
                    grabableObject.Grab(objectGrabPointTransform);
                    return;
                }
            }
            Debug.DrawRay(targ.origin, cam.transform.forward * range, Color.magenta);
        }
        else
        {
            grabableObject.Drop();
            grabableObject = null;

            objectGrabPointTransform.localPosition = objectGrabPointBasePosition;

            return;
        }

        if (Physics.Raycast(targ, out RaycastHit raycastHitButton_, range, buttonLayer))
        {
            if (raycastHitButton_.collider.TryGetComponent(out button))
            {
                button._Button();
                return;
            }
        }

        if (Physics.Raycast(targ, out RaycastHit raycastHitInteractable, range, interactableLayer))
        {
            if (raycastHitInteractable.collider.TryGetComponent(out interactable))
            {
                interactable.Interact();
            }
        }
    }
}
