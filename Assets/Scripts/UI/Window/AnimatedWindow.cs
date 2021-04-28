using System.Collections;

namespace DefaultNamespace.UI
{
    public abstract class AnimatedWindow : Window
    {
        public virtual void OnComplete()
        {
            gameObject.SetActive(false);
        }
        
    }
}