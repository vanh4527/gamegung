using UnityEngine;

public class controller : MonoBehaviour
{
    public CharacterController mycontroller;

    [Header("Cài đặt tốc độ")]
    public float walkSpeed = 8f;
    public float sprintSpeed = 14f;
    public float gravity = -19.81f;
    public float jumpHeight = 2f;

    [Header("Kiểm tra mặt đất")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        // 1. Kiểm tra xem có đang đứng trên mặt đất không
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Giữ nhân vật bám sàn
        }

        // 2. Lấy Input di chuyển (WASD)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // CHỐT: Di chuyển theo hướng của chính Player (đã xoay theo chuột)
        Vector3 move = transform.right * x + transform.forward * z;

        // 3. Xử lý Chạy nhanh (Sprint)
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
        mycontroller.Move(move * currentSpeed * Time.deltaTime);

        // 4. Xử lý Nhảy
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // 5. Áp dụng trọng lực
        velocity.y += gravity * Time.deltaTime;
        mycontroller.Move(velocity * Time.deltaTime);
    }
}