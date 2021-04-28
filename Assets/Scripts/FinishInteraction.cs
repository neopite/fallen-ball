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
        if (other.tag == "Player")
        {
            LevelController.Instance.FinishLevel();
            _winScreen.Open();
        }    
    }
}
