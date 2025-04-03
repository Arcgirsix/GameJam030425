using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float borderViewFieldDown = 25f;
    [SerializeField] private float borderViewFieldUp = -90f;

    [SerializeField] private float mouseSensibility = 10f;

    [SerializeField] private Transform headTransform;

    private float horizontalRotation = 0f;
    private float verticalRotation = 0f;
    private float mouseY;
    private float mouseX;

    private Vector2 moveCamDir;

    private InputSystem_Actions inputActions;
    private InputAction lookAction => inputActions.Player.Look;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();

        lookAction.performed += LookAction_performed;
        lookAction.canceled += LookAction_canceled;
    }

    private void LookAction_canceled(InputAction.CallbackContext obj)
    {
        moveCamDir = lookAction.ReadValue<Vector2>();
        //Debug.Log(lookAction.ReadValue<Vector2>());
    }

    private void LookAction_performed(InputAction.CallbackContext obj)
    {
        moveCamDir = lookAction.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        lookAction.Enable();
    }

    private void OnDisable()
    {
        lookAction.Disable();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {

        mouseX = moveCamDir.x * mouseSensibility * Time.deltaTime;
        mouseY = moveCamDir.y * mouseSensibility * Time.deltaTime;

        verticalRotation -= mouseY;
        horizontalRotation += mouseX;
        verticalRotation = Mathf.Clamp(verticalRotation, borderViewFieldUp, borderViewFieldDown);

        transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);
        headTransform.rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);
    }

}
