using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class BackgroundParticlesController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _backgroundParticle;
        private Transform _particlePoint;
        private CameraController _cameraController;
        [SerializeField] private float _stepRespawn;
        private float _currentStep;

        void Start()
        {
            _particlePoint = _backgroundParticle.GetComponent<Transform>();
            _cameraController = GetComponent<CameraController>();
            _backgroundParticle.Play();
            _currentStep = _cameraController.MinY;
        }

        void Update()
        {
            if (_currentStep > _stepRespawn)
            {
                _particlePoint.position = new Vector3(0, _cameraController.MinY,12);
                _currentStep = 0f;
            }
            else _currentStep += Math.Abs(_cameraController.MinY - _currentStep);
        }

        public void MoveTo(Vector3 target)
        {
            _particlePoint.position = target;
        }
    }
}