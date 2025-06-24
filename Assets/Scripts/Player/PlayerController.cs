using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float Xclamp = 3f;
    [SerializeField] float Zclamp = 3f;

    Vector2 movement;
    Rigidbody rb;

     void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        HandleMovement();


        void HandleMovement()
        {
            Vector3 currentPos = rb.position;
            Vector3 moveDirection = new Vector3 (movement.x, 0f, movement.y);
            Vector3 newPosition = currentPos + moveDirection * (moveSpeed * Time.fixedDeltaTime);

            newPosition.x = Mathf.Clamp(newPosition.x, -Xclamp,Xclamp);
            newPosition.z = Mathf.Clamp(newPosition.z, -Zclamp,Zclamp);

            rb.MovePosition(newPosition);
        }
    }
}
