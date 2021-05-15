using System;
using UnityEngine;

    public class ParallaxCamera : MonoBehaviour
    {
        public delegate void ParallaxMovementHandler(float delta);
        public event ParallaxMovementHandler OnParallaxMove;
        private float _oldPosY;
        
        private void Start()
        {
            _oldPosY = transform.position.y;
        }

        private void Update()
        {
            Vector2 cameraPosition = transform.position;
            if (cameraPosition.y != _oldPosY)
            {
                if (OnParallaxMove != null)
                {
                    float deltaY = cameraPosition.y - _oldPosY ;
                    deltaY = -deltaY; //invert 
                    OnParallaxMove.Invoke(deltaY);
                }
                _oldPosY = cameraPosition.y;
            }
        }
    }
