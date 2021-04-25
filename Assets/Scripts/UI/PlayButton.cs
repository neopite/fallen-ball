using System;
using UnityEngine;

namespace DefaultNamespace.UI
{
    public class PlayButton : AnimatedWindow
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private SceneLoader _sceneLoader;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public override void Open()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.LeanAlpha(1f, .5f).setOnComplete(OpenSettings);
        }

        public override void Close()
        {
            throw new System.NotImplementedException();
        }
        
        private void OpenSettings()
        {
            _mainMenu.SetActive(false);
            _sceneLoader.LoadScene(1);
        }
    }
}