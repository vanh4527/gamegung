using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour
{
    public Rigidbody rb;
    public CharacterController mycontroller;
    public Animator animator;
    public bool isGrounded = false;

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


    void Update()
    {
        

        
        // 2. Lấy Input di chuyển
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // Giới hạn tốc độ khi đi chéo
        if (move.magnitude > 1) move.Normalize();

        // Animation di chuyển
        animator.SetBool("isWalking", move.magnitude > 0.1f);

        // 3. Xử lý Chạy nhanh
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
        mycontroller.Move(move * currentSpeed * Time.deltaTime); // Dùng deltaTime

        // 4. Xử lý Nhảy (Chỉ gọi Trigger khi thỏa điều kiện)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Reset vận tốc Y về 0 trước khi nhảy để lực luôn đều
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            rb.AddForce(Vector3.up * 1, ForceMode.Impulse);
            animator.SetTrigger("Jump");
        }
        if (isGrounded==false) animator.ResetTrigger("Jump");

        // 5. Áp dụng trọng lực
        velocity.y += gravity * Time.deltaTime; // Dùng deltaTime
        mycontroller.Move(velocity * Time.deltaTime);
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = false;
    }
    }   
}