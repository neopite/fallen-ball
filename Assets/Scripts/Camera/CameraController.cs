using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Parameters")] [SerializeField]
    private string _targetTag;
    [SerializeField][Range(0,1)] private float _cameraSpeed;

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
        _cameraTransform.position = new Vector3(0, _mainPlayerPos.position.y, -10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetMove = new Vector3()
        {
            x = 0,
            y = _mainPlayerPos.position.y,
            z = -10
        };
        Vector3 curPos = Vector3.Lerp(_cameraTransform.position, targetMove, _cameraSpeed);
        _cameraTransform.position = curPos;
    }
}
