using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private Transform _targetPos;
    private Material _material;

    void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0f, _targetPos.position.y / 100f);
        _material.mainTextureOffset = offset;
    }
}
