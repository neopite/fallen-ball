using System;
using UnityEngine;

namespace Enemy
{
    public class RotatingPlatform : MonoBehaviour
    {
        [SerializeField] private float _rotatingSpeed;
        [SerializeField] private Vector3 _rotationDirection;
        private Transform _platformTransform;

        public void Start()
        {
            _platformTransform = GetComponent<Transform>();
        }

        public void Update()
        {
            float smooth = _rotatingSpeed * Time.deltaTime;
            _platformTransform.Rotate(_rotationDirection * smooth);
        }
    }
}