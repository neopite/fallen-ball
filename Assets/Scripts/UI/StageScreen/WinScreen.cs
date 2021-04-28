using DefaultNamespace.UI;
using UnityEngine;

namespace UI
{
    public class WinScreen : AnimatedWindow 
    {
        [SerializeField] private CanvasGroup _background;
        [SerializeField] private RectTransform _winMenu;

        public override void Open()
        {
            gameObject.SetActive(true);
            _background.alpha = 0;
            _background.LeanAlpha(0.5f, 1f);
            _winMenu.localPosition = new Vector3(0, +Screen.height);
            _winMenu.LeanMoveLocalY(0, 0.5f).setEaseOutQuint().delay = 0.1f;
        }

        public override void Close()
        {
            _background.alpha = 0.5f;
            _background.LeanAlpha(0f, 1f);
            _winMenu.LeanMoveLocalY(-Screen.height, 0.5f).setEaseOutQuint().delay = 0.1f;
        }
    }
}