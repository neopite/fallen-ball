using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Singleton;
using UI;
using UnityEngine;

public class FinishInteraction : MonoBehaviour
{
    [SerializeField] private WinScreen _winScreen;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        LevelController levelController = Singleton<LevelController>.Instance;
        if (other.tag == "Player" && !levelController.IsLevelFinished)
        {
            levelController.FinishLevel();
            other.GetComponent<Rigidbody2D>().gravityScale = 0f;
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0.2f);
            levelController.IsLevelFinished = true;
            _winScreen.Open();
        }    
    }
}
