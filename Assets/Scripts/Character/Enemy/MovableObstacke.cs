using DefaultNamespace;
using DefaultNamespace.Enemy;
using UnityEngine;
using UnityEngine.UIElements;

namespace Enemy
{
    public class MovableObstacke : MonoBehaviour,IMovable
    {
        [SerializeField] private float _length;
        [SerializeField] private float _speed;
        [SerializeField] private Vector2 _currentMovingDirection;
        private Transform _obstaclePosition;

        void Start()
        {
            _obstaclePosition = GetComponent<Transform>();
        }

        void Update()
        {
            Move();
        }

        public void Move()
        {
            Vector2 move = new Vector2()
            {
                x = _currentMovingDirection.x * _speed * Time.deltaTime,
                y = _currentMovingDirection.y*_speed*Time.deltaTime
            };
            
            Vector2 target = Vector2.Lerp(_obstaclePosition.position,new Vector2(_currentMovingDirection.x*_length,_obstaclePosition.position.y),_speed);
            _obstaclePosition.position = target;
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