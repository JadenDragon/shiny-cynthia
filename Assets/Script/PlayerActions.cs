using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    private PlayerControls playerControls;

    private void Awake()
    {
        //creating control instances
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        //enables the actionmap
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        OnPlayerMove();
    }

    void OnPlayerMove()
    {
        Vector2 move = playerControls.Land.Move.ReadValue<Vector2>();
        Debug.Log("player is moving" + move);
        /*playerControls.Land.Jump.ReadValue<float>();
        if (playerControls.Land.Jump.ReadValue<float>() == 1) { }*/
        if (playerControls.Land.Jump.triggered)
        {
            Debug.Log("player can jump");
        }
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
