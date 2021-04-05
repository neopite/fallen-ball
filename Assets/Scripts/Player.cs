using UnityEngine;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour,IDamagable
    {
        public void ReceiveDamage()
        {
            Destroy(gameObject);
        }
    }
}