using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace DefaultNamespace.UI
{
    public class UIController : MonoBehaviour
    {
        public static UIController Instance;
        public Window loseScreen;
        private Window _currentWindow;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}