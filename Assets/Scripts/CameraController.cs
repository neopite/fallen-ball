using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private string _tagOfTarget;
    [SerializeField] private float _cameraSpeed; 
    
    private Transform _mainPlayerPos;
    private Transform _cameraTransform;

    [SerializeField]private float _minY;

    public float MinY
    {
        get { return _minY; }
        private set { _minY = value; }
    }

    void Start()
    {
        if (_tagOfTarget == null)
        {
            _tagOfTarget = "Player";
        }
        _mainPlayerPos = GameObject.FindWithTag(_tagOfTarget).transform;
        _cameraTransform = GetComponent<Transform>();
        _cameraTransform.position = new Vector3(0,_mainPlayerPos.position.y , -10);
        MinY = _cameraTransform.position.y - 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_mainPlayerPos)
        {
            if (_mainPlayerPos.position.y - MinY < 5)
            {
                Vector3 targetMove = new Vector3()
                {
                    x = 0,
                    y = _cameraTransform.position.y,
                    z = -10
                };
                Vector3 curPos = Vector3.Lerp(_cameraTransform.position, targetMove, _cameraSpeed);
                _cameraTransform.position = curPos;
            }
            else
            {
                // if(_mainPlayerPos.position.y > _minY)
                Vector3 targetMove = new Vector3()
                {
                    x = 0,
                    y = _mainPlayerPos.position.y,
                    z = -10
                };
                Vector3 curPos = Vector3.Lerp(_cameraTransform.position, targetMove, _cameraSpeed);
                _cameraTransform.position = curPos;
            }
            if (MinY < _cameraTransform.position.y - 5) MinY = _cameraTransform.position.y - 5;
        }
    }
}
