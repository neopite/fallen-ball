using System;
using DefaultNamespace;
using DefaultNamespace.Enemy;
using UnityEngine;

namespace Character.Enemy.Characters
{
    public class ColliderHitEnemy : MonoBehaviour , IDamageDealer
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Player>(out Player player))
            {
                DealDamage(player);
            }
        }

        public void DealDamage(Player player)
        {
            player.ReceiveDamage();
        }
    }
}