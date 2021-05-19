using System;
using TMPro;
using UnityEngine;

namespace UI.Button
{
    public class LevelNodeButton : AnimatedButton
    {
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _levelMenu;
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private TextMeshProUGUI _levelIndex;
        
        public override void Click()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.LeanAlpha(1f, .5f).setOnComplete(OnCompleteAnimationAction);
        }

        public override void OnCompleteAnimationAction()
        {
            _levelMenu.SetActive(false);
            _mainMenu.SetActive(true);
            if (Int32.TryParse(_levelIndex.text, out int result)) _sceneLoader.LoadScene(result);
        }
    }
}