using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public WinLossController winLossController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        winLossController.CompleteLevel();
    }
}
