using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;

    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool grounded;

    void Update()
    {
        grounded = checkGround();
        if (grounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -1f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    bool checkGround()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Touching");
        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
        }

    }
}
