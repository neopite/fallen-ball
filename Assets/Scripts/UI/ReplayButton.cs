using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ReplayButton : MonoBehaviour
{
    private SceneLoader _loader;
    void Start()
    {
        _loader = GetComponent<SceneLoader>();
    }

    public void ReloadLevel()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        _loader.LoadScene(currentLevel);
    }
   
}
