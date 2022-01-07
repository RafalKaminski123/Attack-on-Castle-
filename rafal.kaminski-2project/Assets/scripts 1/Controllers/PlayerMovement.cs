using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int playerSpeed = 6;
    public int playerJumpPower = 500;
    private float moveX;
    public bool isGrounded;
    public float bottomPlayerDistance = 1.3f;
    

    private void Update()
    {
        PlayerMove();
        PlayerRaycast();
    }

    void PlayerMove()
    {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal"); 
        if(Input.GetButtonDown ("Jump") && isGrounded == true)
        {
            Jump();
        }

        //ANIMATING
        if(moveX != 0)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", false);
        }

        if (isGrounded == false)
        {
            GetComponent<Animator>().SetBool("Jump", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Jump", false);
        }
        //PLAYER DIRECTION
        if(moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump() //JUMP
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }
    

    void PlayerRaycast()
    {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if ( hit.collider != null && hit.distance < bottomPlayerDistance && hit.collider.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);

            //Do usunięcia przy nowym systemie walki//
            hit.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 200);  
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            hit.collider.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
            hit.collider.gameObject.GetComponent<EnemyMove>().enabled = false;
        }
        if ( hit.collider != null && hit.distance < bottomPlayerDistance && hit.collider.tag != "Enemy")
        {
            isGrounded = true;
        }
    }
}

