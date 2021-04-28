using System;
using DefaultNamespace.UI;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class GamePause : MonoBehaviour
    {
        public static GamePause Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }else Destroy(gameObject);
        }

        public void PauseGame()
        {
            UIController.Instance.pauseScreen.Open();
            Time.timeScale = 0;
        }

        public void UnpauseGame()
        {
            UIController.Instance.pauseScreen.Close();
            Time.timeScale = 1;
        }
    }
}