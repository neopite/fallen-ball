using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]private Transform _platformTransform;
    [SerializeField] private Vector3 _movingDirection;
    [SerializeField][Range(0, 40)] private float _speed;
    [SerializeField] [Range(0, 10)] private float _distance;
    private bool _isFliped;
    private Vector3 _startPosition;
    private Rigidbody2D _platformRg;
    private Vector2 _movingVector;
    
    void Start()
    {
        _startPosition = _platformTransform.position;
        _platformRg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 destinationVector = _isFliped ? _startPosition : _startPosition + (_movingDirection * _distance); ;
        _movingVector = _movingDirection * (_speed * Time.deltaTime);
        if ((destinationVector - _platformTransform.position ).magnitude < 0.05)
        {
            _movingDirection = -_movingDirection;
             _isFliped = !_isFliped;
        }
        _platformRg.velocity = _movingVector;
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (_movingDirection.x != 0)
        {
            Gizmos.DrawCube(_platformTransform.position+(_movingDirection*_distance),new Vector3(0.2f,0.8f,1f));   
        }else Gizmos.DrawCube(_platformTransform.position+(_movingDirection*_distance),new Vector3(0.8f,0.2f,1f)); 
    }
}
