using UnityEngine;

namespace DefaultNamespace.UI
{
    public abstract class Window  : MonoBehaviour
    {
         public abstract void Open();
         public abstract void Close();
    }
}