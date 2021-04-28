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
        PlayerPrefs.SetInt("LevelComplete",_levelCompleteIndex);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(_levelCompleteIndex+1);
    }
}
