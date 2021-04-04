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
    void Start()
    {
        if (_tagOfTarget == null)
        {
            _tagOfTarget = "Player";
        }
        _mainPlayerPos = GameObject.FindWithTag(_tagOfTarget).transform;
        _cameraTransform = GetComponent<Transform>();
        _cameraTransform.position = new Vector3(0,_mainPlayerPos.position.y , -10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_mainPlayerPos)
        {
            Vector3 targetMove = new Vector3()
            {
                x = 0,
                y = _mainPlayerPos.position.y,
                z = -10
            };
            Vector3 curPos = Vector3.Lerp(_cameraTransform.position,targetMove,_cameraSpeed);
            _cameraTransform.position = curPos;
        }
    }
}
