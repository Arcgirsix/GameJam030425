using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrab : MonoBehaviour
{
    public Camera cam;
    [SerializeField] private float range = 3.0f;

    [SerializeField] private LayerMask itemLayer = 3;
    [SerializeField] private LayerMask interactableLayer = 3;

    private InputSystem_Actions inputActions;
    private InputAction interactAction => inputActions.Player.Interact;

    [SerializeField] private Transform objectGrabPointTransform;
    private GrabableObject grabableObject;
    private Interactable interactable;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();

        interactAction.performed += InteractAction_performed;
    }

    private void InteractAction_performed(InputAction.CallbackContext obj)
    {
        Grab();
    }

    private void OnEnable()
    {
        interactAction.Enable();
    }

    private void OnDisable()
    {
        interactAction.Disable();
    }

    private void Start()
    {
        cam = Camera.main;
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
            return;
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
