using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        float currentSpeed = movement.magnitude;

        // This line updates the "Speed" parameter in your Animator controller
        animator.SetFloat("Speed", currentSpeed);
    }
}