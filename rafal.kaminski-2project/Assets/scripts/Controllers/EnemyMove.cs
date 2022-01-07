using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour

{
    public int enemySpeed = 6;
    public int moveDirection;
    public bool facingRight = true;
    public WinLossController winLossController;


    void Update()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(moveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection, 0) * enemySpeed;
        if(hit.distance < 1.1f)
            {
            FlipEnemy();
           if(hit.collider.tag == "PlayerTwo")
            {
                Destroy(hit.collider.gameObject);
                winLossController.LostLevel();
            }
        }

        if(gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
        }


    }
    void FlipEnemy()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

        if (moveDirection > 0 && facingRight == false)
        {
            moveDirection = -1;
        }
        else
        {
            moveDirection = 1;
        }
    }





}
