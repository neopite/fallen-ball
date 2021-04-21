using System;
using DefaultNamespace.Enemy;
using UnityEngine;

namespace Character.Enemy.Obstacles
{
    public class Saw : MonoBehaviour , IMovable
    {
        [SerializeField] private Collider2D _sliderCollider;
        [SerializeField]private Vector3 _movingDirection;
        [SerializeField][Range(1,10)]private float _speed;
        private Vector3 _startPosition;
        private Rigidbody2D _sawRg;
        
        private bool _isFliped;
        private float _distance;

        private void Start()
        {
            _sawRg = GetComponent<Rigidbody2D>();
            _startPosition = transform.localPosition;
            SetDistance();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void Move()
        {
            Vector3 destinationVector = _isFliped ?(_movingDirection * _distance) -_startPosition : _startPosition + (_movingDirection * _distance);
            Debug.Log(destinationVector);
            Vector3 _moveTotalVector = _movingDirection * (_speed);
            if ((destinationVector - transform.localPosition ).magnitude < 0.05)
            {
                _movingDirection = -_movingDirection;
                _isFliped = !_isFliped;
            }
            _sawRg.velocity = _moveTotalVector;
        }

        private void SetDistance()
        {
            if (_movingDirection.x != 0)
            {
                _distance = _sliderCollider.bounds.extents.x + _sliderCollider.bounds.center.x;
                _sawRg.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }else if (_movingDirection.y != 0)
            {
                _distance = _sliderCollider.bounds.extents.y + _sliderCollider.bounds.center.y;
                _sawRg.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}