using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _levelMenu;
    
    public void LoadLevelFromMenu(int scene)
    {
        _mainMenu.SetActive(true);
        _levelMenu.SetActive(false);
        SceneManager.LoadScene(scene);
    }
}
