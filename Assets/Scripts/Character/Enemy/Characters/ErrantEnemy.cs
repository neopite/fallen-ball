using System;
using DefaultNamespace;
using DefaultNamespace.Enemy;
using UnityEngine;

namespace Character.Enemy.Characters
{
    public class ErrantEnemy : MonoBehaviour , IMovable
    {
        [SerializeField] [Range(0, 20)] private float _speed;
        private Rigidbody2D _enemyRg;
        private SpriteRenderer _sprite;
        private Vector3 _direction = Vector3.right;

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _enemyRg = GetComponent<Rigidbody2D>();
        }


        public void Update()
        {
            Move();
        }
        
        public void Move()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position - (Vector3.up*0.5f) +transform.right * (_direction.x * 0.5f), 0.2f);
            //Debug.DrawRay(transform.position-(Vector3.up*0.5f),transform.right * (_direction.x * 1.5f));  colliders detection debug ray
            if (colliders.Length == 1)
            {
                _direction *= -1f;
                _sprite.flipX = !_sprite.flipX;
            }
            transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, Time.deltaTime * _speed);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag.Equals("Player"))
            {
                other.GetComponent<Player>().ReceiveDamage();
            }
        }
    }
}