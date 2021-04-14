using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class StaticObstacle : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag.Equals("Player"))
            {
                other.GetComponent<Player>().ReceiveDamage();
            }
        }
    }
}