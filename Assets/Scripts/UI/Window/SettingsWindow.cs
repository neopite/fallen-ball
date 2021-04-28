using UnityEngine;

namespace DefaultNamespace.UI
{
    public class SettingsWindow : AnimatedWindow
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private GameObject _settingMenu;
        [SerializeField] private GameObject _mainMenu; 
        
        public override void Open()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.LeanAlpha(1f, .5f).setOnComplete(OpenSettings);
        }

        public override void Close()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.LeanAlpha(1f, .5f).setOnComplete(CloseSettings);
        }

        private void OpenSettings()
        {
            _settingMenu.SetActive(true);
            _mainMenu.SetActive(false);
            _canvasGroup.alpha = 1;
            _canvasGroup.LeanAlpha(0f, .5f);
        }
        
        private void CloseSettings()
        {
            _settingMenu.SetActive(false);
            _mainMenu.SetActive(true);
            _canvasGroup.alpha = 1;
            _canvasGroup.LeanAlpha(0f, .5f);
        }

    }
}