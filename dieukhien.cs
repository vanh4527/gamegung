using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieukhien : MonoBehaviour
{
    public Rigidbody rb;
    public bool isGrounded = false;
    void Start()
    {
        Debug.Log("Start");
    }

    void Update()
    {
        Debug.Log("Loops Move");
        HandleMovement();
    }

    public void HandleMovement()
    {
        float updown = Input.GetAxis("Horizontal");
        float rightleft = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(updown, 0, rightleft);

        rb.MovePosition(transform.position + movement * 5 * Time.fixedDeltaTime);

    }
    
}