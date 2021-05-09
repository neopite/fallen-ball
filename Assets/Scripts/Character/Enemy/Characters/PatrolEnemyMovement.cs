using System.Collections;
using DefaultNamespace.Enemy;
using UnityEngine;

namespace Character.Enemy.Characters
{
    public class PatrolEnemyMovement : MonoBehaviour, IMovable
    {
        [SerializeField] private Transform _platformTransform;
        [SerializeField] private Vector3 _movingDirection;
        [SerializeField] [Range(0, 10)] private float _speed;
        [SerializeField] [Range(0, 10)] private float _distance;
        [SerializeField] [Range(0, 10)] private float _stopDelay;
        private bool _isFliped;
        private bool _isMoving;
        private Vector3 _startPosition;
        private Rigidbody2D _platformRg;
        private Vector2 _movingVector;
        private SpriteRenderer _spriteRenderer;

        void Start()
        {
            _startPosition = _platformTransform.position;
            _platformRg = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _isMoving = true;
            FreezePlatformPosition();
        }

        void FixedUpdate()
        {
            Move();
        }

        public IEnumerator MoveWithDelay()
        {
            if (_isMoving)
            {
                Vector3 destinationVector =
                    _isFliped ? _startPosition : _startPosition + (_movingDirection * _distance);
                ;
                _movingVector = _movingDirection * (_speed);
                if ((destinationVector - _platformTransform.position).magnitude < 0.05)
                {
                    _movingDirection = -_movingDirection;
                    _platformRg.velocity = new Vector2(0,0);
                    _isMoving = false;
                    yield return new WaitForSeconds(_stopDelay);
                    _spriteRenderer.flipX = _isFliped;
                    _isMoving = true;
                    _isFliped = !_isFliped;
                }
                _platformRg.velocity = _movingVector;
            }
        }
        
        public void Move()
        {
            StartCoroutine(MoveWithDelay());
        }
        

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            if (_movingDirection.x != 0)
            {
                Gizmos.DrawCube(_platformTransform.position + (_movingDirection * _distance),
                    new Vector3(0.2f, 0.8f, 1f));
            }
            else
                Gizmos.DrawCube(_platformTransform.position + (_movingDirection * _distance),
                    new Vector3(0.8f, 0.2f, 1f));
        }

        private void FreezePlatformPosition()
        {
            if (_movingDirection.x != 0)
            {
                _platformRg.constraints =
                    RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
            else if (_movingDirection.y != 0)
            {
                _platformRg.constraints =
                    RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}