﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _cooldownForNextJumping;
    private float _currentCooldownRemainTime;
    private Rigidbody2D _playerRG;
    private PlayerMovement _playerMovement;
    private SpriteRenderer _sprite;
    

    void Start()
    {
        _playerRG = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponent<PlayerMovement>();
        _sprite = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (_currentCooldownRemainTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(EventSystem.current.IsPointerOverGameObject()) return; //UI layer
                float clickSide = GetClickSideNumber();
                _playerMovement.Move(new Vector3(clickSide / 2, 0.5f, 0));
                _currentCooldownRemainTime = _cooldownForNextJumping;
                _sprite.flipX = clickSide == -1 ? false : true;
            } 
        }else
        {
            _currentCooldownRemainTime -= Time.deltaTime;
        }
    }

    private float GetClickSideNumber()
    {
        return Screen.width / 2 > Input.mousePosition.x ? -1 : 1;
    }
}
