using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public bool canMove;
    public Rigidbody2D rb;
    private Vector2 playerDirection;
    public KeyCode[] PlayerKeys;

    public bool isHugging;

    private void Start()
    {

    }

    void Update()
    {
        foreach(KeyCode key in PlayerKeys)
        {
            if (Input.GetKeyDown(key))
            {
                //Debug.Log("this player is pressing their keys!");
                float directionX = Input.GetAxisRaw("Horizontal");
                float directionY = Input.GetAxisRaw("Vertical");
                playerDirection = new Vector2(directionX, directionY).normalized;
                canMove = true;
            }
            else if (Input.GetKeyUp(key))
            {
                //Debug.Log("this player STOPPED pressing their keys");
                canMove = false;
            }
        }
    }
    void FixedUpdate()
    {
        if (canMove)
        {
            rb.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
        }
    }

    
}
