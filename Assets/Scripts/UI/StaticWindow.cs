using System;
using UnityEngine;

namespace DefaultNamespace.UI
{
    public class StaticWindow : Window
    {
        public override void Open()
        {
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            gameObject.SetActive(false);
        }
    }
}