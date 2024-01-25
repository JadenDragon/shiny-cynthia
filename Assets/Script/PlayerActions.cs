using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    private PlayerControls playerControls = null;
    private Rigidbody rigibod = null;

    [SerializeField]
    private float moveSpeed = 10f;
    private float jumpForce = 25f;
    private bool isGrounded = false;
    private bool isCrouching = false;

    private void Awake()
    {
        //creating control instances
        playerControls = new PlayerControls();
        rigibod = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        //enables the actionmap
        playerControls.Enable();
        //playerControls.Land.Move.performed += OnPlayerMove;
    }

    private void OnDisable()
    {
        playerControls.Disable();
        //playerControls.Land.Move.performed -= OnPlayerMove;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        OnPlayerMove();
    }

    void OnPlayerMove()
    {
        Vector2 move = playerControls.Land.Move.ReadValue<Vector2>();

        rigibod.velocity = new Vector3(move.x * moveSpeed, rigibod.velocity.y, rigibod.velocity.z);
        Debug.Log("player is moving" + move);

        //rotates the capsule facing direction
        if (move.x > 0)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }
        if (move.x < 0)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }

        /*playerControls.Land.Jump.ReadValue<float>();
        if (playerControls.Land.Jump.ReadValue<float>() == 1) { }*/
        if (playerControls.Land.Jump.triggered)
        {
            Debug.Log("player can jump");
        }
    }

    void onPlayerJump()
    {
        isGrounded = true;
        Vector2 jumping = playerControls.Land.Jump.ReadValue<Vector2>();
        transform.position.y = transform.position.y * jumpForce;
    }

/*    void MyPlayerActions()
    {

    }*/

     void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        //get start position of line and add it with its own right position
        //multiply the right position to make line longer
        Gizmos.DrawLine(transform.position, transform.position + transform.right * 3);
    }
}
