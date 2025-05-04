using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "DeathTrigger")
        {
            LevelManager.Instance.StopGame();
        }
    }
}
