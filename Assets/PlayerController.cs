using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public bool isPlayerL = false;
    public bool isMultiPlayer = false;
    public GameObject circle;
    private Rigidbody2D rb;
    private Vector2 playerMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isPlayerL){
            PaddleLController();  // Left player controlled by W and S
        }
        else{
            PaddleRController();  // Right player controlled by AI
        }
    }

    private void PaddleRController()
    {
        if(isMultiPlayer){
            playerMovement = Vector2.zero;  // Reset movement

            if (Input.GetKey(KeyCode.UpArrow))
            {
                playerMovement.y = 1;  // Move up
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                playerMovement.y = -1;  // Move down
            }
            else
            {
                playerMovement.y = 0;  // No movement if neither W nor S is pressed
            }
            
        }
        else{
            if (circle.transform.position.y > transform.position.y + 1.5f)
            {
                playerMovement = new Vector2(0, 1);
            }
            else if (circle.transform.position.y < transform.position.y - 1.5f)
            {
                playerMovement = new Vector2(0, -1);
            }
            else
            {
                playerMovement = new Vector2(0, 0);
            }
        } 
        // Basic AI logic for the right paddle
        
    }

    private void PaddleLController()
    {
        // Controls for the left player using W and S keys
        playerMovement = Vector2.zero;  // Reset movement

        if (Input.GetKey(KeyCode.W))
        {
            playerMovement.y = 1;  // Move up
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerMovement.y = -1;  // Move down
        }
        else
        {
            playerMovement.y = 0;  // No movement if neither W nor S is pressed
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = playerMovement * speed;  // Apply the calculated movement
    }
}
