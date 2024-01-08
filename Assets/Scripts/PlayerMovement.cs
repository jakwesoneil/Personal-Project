using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform orientation;
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float sprintSpeed = 12f;  // Adjust sprint speed as needed
    [SerializeField] float acceleration = 10f;
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
    }

    void MyInput()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
        moveDirection.Normalize();

        ControlSpeed(moveDirection);
    }

    void ControlSpeed(Vector3 moveDirection)
    {
        float targetSpeed = Input.GetKey(sprintKey) ? sprintSpeed : moveSpeed;

        Vector3 targetVelocity = new Vector3(moveDirection.x * targetSpeed, rb.velocity.y, moveDirection.z * targetSpeed);
        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, acceleration * Time.deltaTime);
    }
}
