using System;
using DefaultNamespace;
using DefaultNamespace.Enemy;
using UnityEngine;

namespace Character.Enemy.Characters
{
    public class ColliderHitEnemy : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Player>(out Player player))
            {
                other.GetComponent<Player>().ReceiveDamage();
            }
        }
    }
}