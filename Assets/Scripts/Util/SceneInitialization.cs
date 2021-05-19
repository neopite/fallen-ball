using System;
using Singleton;
using UnityEngine;

namespace DefaultNamespace
{
    public class SceneInitialization : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField]private SceneLoader _sceneLoader;
        
        public void Awake()
        {
            OpenScene();
        }

        public void OpenScene()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.LeanAlpha(0f, 1f);
        }

        public void closeScene(int toScene)
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.LeanAlpha(1f, 1f).setOnComplete(() => OnCompletee(toScene));
        }
        
        private void OnCompletee(int toScene)
        {
            if(Time.timeScale == 0 ) Singleton<GamePause>.Instance.UnpauseGame();
            _sceneLoader.LoadScene(toScene);
        }
    }
}