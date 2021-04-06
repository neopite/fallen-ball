using UnityEngine;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour,IDamagable
    {
        [SerializeField] private ParticleSystem _deadParicle;
        public void ReceiveDamage()
        {
            ParticleSystem particleSystem = (ParticleSystem)Instantiate(_deadParicle, gameObject.transform.position, Quaternion.identity);
            particleSystem.Play();
            Destroy(gameObject);
        }
    }
}