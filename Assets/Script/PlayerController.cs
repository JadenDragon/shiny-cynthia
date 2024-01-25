using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 25f;
    private bool isGrounded = false;
    private bool isCrouching = false;
    
    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;

    //private float crouchHeight = 1;
    private float crouchPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }*/
        /*if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            Debug.Log("jumping");
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Shift is pressed");
        }*/
        MyPlayerMovement();
    }

    void MyPlayerMovement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            Debug.Log("jumping");
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("LeftCtrl is pressed");
            //transform.localScale = Vector3.Scale(transform.localScale, transform.localScale / 3);


            if (isCrouching == false)
            {
                // Modify the size properties as needed
                capsuleCollider.center = new Vector3(0f, -0.5f, 0f); // Example center position
                capsuleCollider.radius = 0.5f; // Example radius
                capsuleCollider.height = 1.0f; // Example height

                isCrouching = true;
                Debug.Log("GET DOWN!");
            }
            else {
                // Modify the size properties as needed
                capsuleCollider.center = new Vector3(0f, 0f, 0f); // Example center position
                capsuleCollider.radius = 0.5f; // Example radius
                capsuleCollider.height = 2.0f; // Example height

                isCrouching = false;
                Debug.Log("STAND UP!");
            }
                      

            
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("has jumped");
        }

        Debug.Log("does this work ???");
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        //get start position of line and add it with its own right position
        //multiply the right position to make line longer
        Gizmos.DrawLine(transform.position, transform.position + transform.right * 3);
    }
}
