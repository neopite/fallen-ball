using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UI;
using UnityEngine;

public class FinishInteraction : MonoBehaviour
{
    [SerializeField] private WinScreen _winScreen;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !LevelController.Instance.IsLevelFinished)
        {
            LevelController.Instance.FinishLevel();
            other.GetComponent<Rigidbody2D>().gravityScale = 0f;
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0.2f);
            LevelController.Instance.IsLevelFinished = true;
            _winScreen.Open();
        }    
    }
}
