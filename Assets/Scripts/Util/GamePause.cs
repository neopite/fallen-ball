using System;
using DefaultNamespace.UI;
using Singleton;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class GamePause : MonoBehaviour
    {
        public void PauseGame()
        {
            Singleton<UIController>.Instance.pauseScreen.Open();
            Time.timeScale = 0;
        }

        public void UnpauseGame()
        {
            Singleton<UIController>.Instance.pauseScreen.Close();
            Time.timeScale = 1;
        }
    }
}