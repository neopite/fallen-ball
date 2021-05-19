using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _levelMenu;
    
    public void LoadLevel(int scene)
    {
        SceneManager.LoadScene(scene);
        _mainMenu.SetActive(true);
        _levelMenu.SetActive(false);
    }
}
