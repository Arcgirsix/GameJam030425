using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    private InputSystem_Actions inputActions;
    private InputAction moveAction => inputActions.Player.Move;

    public float moveSpeed;
    private Vector2 moveDir;
    private Vector3 playerVelocity;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();

        moveAction.performed += MoveAction_performed;
        moveAction.canceled += MoveAction_canceled;
    }

    private void MoveAction_canceled(InputAction.CallbackContext obj)
    {
        moveDir = moveAction.ReadValue<Vector2>();
    }

    private void MoveAction_performed(InputAction.CallbackContext obj)
    {
        moveDir = moveAction.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void FixedUpdate()
    {
        playerVelocity = new Vector3(moveDir.x * moveSpeed, rb.linearVelocity.y, moveDir.y * moveSpeed);
        rb.linearVelocity = transform.TransformDirection(playerVelocity);
    }
}
