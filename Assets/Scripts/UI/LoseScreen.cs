using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.UI;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : AnimatedWindow
{
    [SerializeField] private CanvasGroup _background;
    [SerializeField] private RectTransform _lostMenu;

    public override void Open()
    {
        gameObject.SetActive(true);
        _background.alpha = 0;
        _background.LeanAlpha(0.5f, 1f);
        _lostMenu.localPosition = new Vector3(0, -Screen.height);
        _lostMenu.LeanMoveLocalY(0, 0.5f).setEaseOutQuint().delay = 0.1f;
    }

    public override void Close()
    {
        _background.alpha = 0.5f;
        _background.LeanAlpha(0f, 1f);
        _lostMenu.LeanMoveLocalY(-Screen.height, 0.5f).setEaseOutQuint().delay = 0.1f;
    }
    
}
