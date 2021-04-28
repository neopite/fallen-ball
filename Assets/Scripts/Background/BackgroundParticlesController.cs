using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class BackgroundParticlesController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _backgroundParticle;
        [SerializeField] private float _stepRespawn;
        private Transform _particlePoint;
        private Transform _camera;
        private float _currentStep;
        private float _prevYValue;

        void Start()
        {
            _particlePoint = _backgroundParticle.GetComponent<Transform>();
            _particlePoint.position = new Vector3(0, -5, 5);
            _camera = Camera.main.transform;
            _backgroundParticle.Play();
        }

        void Update()
        {
            Vector2 currPosition = _camera.transform.position;
            if (Math.Abs(_currentStep) > _stepRespawn)
            {
                _particlePoint.position = new Vector3(0, _particlePoint.position.y + (_currentStep<0?-5:5),5);
                _currentStep = 0;
            }
            else _currentStep += currPosition.y - _prevYValue;
                    
            _prevYValue =currPosition.y;
        }

        public void MoveTo(Vector3 target)
        {
            _particlePoint.position = target;
        }
    }
}