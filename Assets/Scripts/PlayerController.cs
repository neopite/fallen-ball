using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRG;
    private PlayerMovement _playerMovement;

    void Start()
    {
        _playerRG = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponent<PlayerMovement>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerMovement.Move(new Vector3(GetClickSideNumber()/2 ,0.5f,0));
        }
    }

    private float GetClickSideNumber()
    {
        return Screen.width / 2 > Input.mousePosition.x ? -1 : 1;
    }
}
