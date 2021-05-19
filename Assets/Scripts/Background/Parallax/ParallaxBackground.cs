using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

    public class ParallaxBackground : MonoBehaviour
    {
        [SerializeField] private ParallaxCamera _parallaxCamera;
        private List<ParallaxLayer> _layers;
        
        private void Start()
        {
            _layers = GetComponentsInChildren<ParallaxLayer>().ToList();
            if (_parallaxCamera != null) _parallaxCamera.OnParallaxMove += MoveBackground;
        }

        private void MoveBackground(float delta)
        {
            foreach (ParallaxLayer parallaxLayer in _layers)
            {
                parallaxLayer.MoveLayer(delta);
            }
        }
    }