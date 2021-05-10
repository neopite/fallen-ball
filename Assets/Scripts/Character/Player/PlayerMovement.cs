using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float _jumpForce;
    [SerializeField] [Range(-0.5f, 0.5f)] private float _angle;
    private Rigidbody2D _playerRG;
    private Vector3 _jumpDirection;


    void Start()
    {
        _playerRG = GetComponent<Rigidbody2D>();
    }
    
    public void Move(Vector3 direction)
    {
        direction.x = direction.x > 0 ? direction.x + _angle : direction.x - _angle; 
        if (_playerRG.velocity.magnitude > 0.1f)
        {
            _playerRG.velocity = Vector2.zero;
            
        } 
        _playerRG.AddForce(direction*_jumpForce,ForceMode2D.Impulse);
    }
}
