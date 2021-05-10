using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Parameters")] [SerializeField]
    private string _targetTag;
    [SerializeField][Range(0,1)] private float _cameraSpeed;
    private bool _isPositionOnGroundPoint;
    private Vector3 _cameraStartPosition;
    private Transform _mainPlayerPos;
    private Transform _cameraTransform;
    
    void Start()
    {
        if (_targetTag == null)
        {
            _targetTag = "Player";
        }

        _mainPlayerPos = GameObject.FindWithTag(_targetTag).transform;
        _cameraTransform = GetComponent<Transform>();
        _cameraStartPosition = _cameraTransform.position;
    }
    
    void FixedUpdate()
    {
        Vector2 playerPos = _mainPlayerPos.position;
            if (_isPositionOnGroundPoint)
            {
                Vector3 targetMove = new Vector3()
                {
                    x = 0,
                    y = playerPos.y,
                    z = -10
                };
                Vector3 curPos = Vector3.Lerp(_cameraTransform.position, targetMove, _cameraSpeed);
                _cameraTransform.position = curPos;
            }

            _isPositionOnGroundPoint = playerPos.y > _cameraStartPosition.y ? true : false;
    }
}
