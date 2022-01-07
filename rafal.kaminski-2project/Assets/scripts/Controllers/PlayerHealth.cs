using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public WinLossController winLossController;
    private void Update()
    {
        if (gameObject.transform.position.y < -15)
        {
            Die();
        }
        void Die()
        {
            Destroy(gameObject);
            winLossController.LostLevel();
            
        }
    }
}


