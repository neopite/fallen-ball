using UnityEngine;

namespace UI
{
    public abstract class AnimatedButton : MonoBehaviour
    {
        [SerializeField] protected  CanvasGroup _canvasGroup;
        
        public virtual void Click()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.LeanAlpha(1f, .5f).setOnComplete(OnCompleteAnimationAction);
        }

        public abstract void OnCompleteAnimationAction();
    }
}