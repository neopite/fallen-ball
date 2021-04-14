using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _cooldownForNextJumping;
    private float _currentCooldownRemainTime;
    private Rigidbody2D _playerRG;
    private PlayerMovement _playerMovement;
    

    void Start()
    {
        _playerRG = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponent<PlayerMovement>();
    }
    
    void Update()
    {
        if (_currentCooldownRemainTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _playerMovement.Move(new Vector3(GetClickSideNumber() / 2, 0.5f, 0));
                _currentCooldownRemainTime = _cooldownForNextJumping;
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
