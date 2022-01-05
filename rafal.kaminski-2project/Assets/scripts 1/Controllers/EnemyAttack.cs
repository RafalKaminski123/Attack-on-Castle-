using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public WinLossController winLossController;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerTwo")
        {
            Destroy(collision.gameObject);
            winLossController.LostLevel();
        }
    }

}
 

  
