using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    private int _levelCompleteIndex;
    private bool _isLevelFinished;

    public bool IsLevelFinished { get; set; }

    public void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }else Destroy(Instance);
    }

    public void FinishLevel()
    {
         _levelCompleteIndex = SceneManager.GetActiveScene().buildIndex;
         int lastCompleteLevel = PlayerPrefs.GetInt("LevelComplete");
         if (lastCompleteLevel + 1 == _levelCompleteIndex)
         {
             PlayerPrefs.SetInt("LevelComplete",_levelCompleteIndex);
         }else if (SceneManager.sceneCount - 1 == _levelCompleteIndex)
         { 
             _levelCompleteIndex = SceneManager.GetActiveScene().buildIndex - 1;    
         }
    }
    
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(_levelCompleteIndex+1);
    }
}
