using System;
using UI;
using UnityEngine;

namespace DefaultNamespace.UI
{
    public class PlayButton : AnimatedButton
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private SceneLoader _sceneLoader;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
        
        public override void OnCompleteAnimationAction()
        {
            _mainMenu.SetActive(false);
            _sceneLoader.LoadScene(PlayerPrefs.GetInt("LevelComplete",1));
        }
    }
}