using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField][Range(1,100)] private float _speed;
    [SerializeField] private Transform _targetPos;
    private Material _material;

    void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0f, _targetPos.position.y/ 100f/_speed);
        _material.mainTextureOffset = offset;
    }
    
}
