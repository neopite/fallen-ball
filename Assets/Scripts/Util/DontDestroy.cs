using UnityEngine;

namespace DefaultNamespace
{
    public class DontDestroy : MonoBehaviour
    {
        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}