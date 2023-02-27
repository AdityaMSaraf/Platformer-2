using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DemoPlayerController : MonoBehaviour
{
    public float runForce = 50f;
    public float jumpImpulseForce = 20f;
    public float jumpSustainForce = 7.5f;
    public LayerMask layerMask;
    public float maxHorizontalSpeed = 4f;
    public bool isGrounded = false;
    private Vector3 offset;
    private Vector3 cam;

    private void Start()
    {
        offset = Camera.main.transform.position - transform.position;
    }

    void Update()
    {
        Bounds bounds = GetComponent<Collider>().bounds;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, bounds.extents.y + 0.1f);

        float axis = Input.GetAxis("Horizontal");
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * axis * runForce, ForceMode.Force);

       
        cam = transform.position + offset;
        Camera.main.transform.position = new Vector3(cam.x, 7.5f, cam.z);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpImpulseForce, ForceMode.Impulse);
        }else if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpSustainForce, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxHorizontalSpeed = 8f;
        }
        else
        {
            maxHorizontalSpeed = 4f;
        }

        float xVelocity = Mathf.Clamp(rb.velocity.x, -maxHorizontalSpeed, maxHorizontalSpeed);

        if (Mathf.Abs(axis) < 0.1f)
        {
            xVelocity *= 0.9f;
        }

        rb.velocity = new Vector3(xVelocity, rb.velocity.y, rb.velocity.z);

        if(rb.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        if(rb.velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
        }
        

        float horizontalSpeed = Mathf.Abs(rb.velocity.x);
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("Speed", horizontalSpeed);
        animator.SetBool("Jumping", isGrounded);
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Death(Clone)")
        {
            gameObject.SetActive(false);
            Debug.Log("YOU DIED!");
        } else  if(collision.gameObject.name == "Goal(Clone)")
        {
            gameObject.SetActive(false);
            Debug.Log("YOU WIN!!! (yay)");
        }
    }
}