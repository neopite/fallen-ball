using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvInteraction : MonoBehaviour
{
    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) _animator.SetTrigger("isInteract");
    }
}
