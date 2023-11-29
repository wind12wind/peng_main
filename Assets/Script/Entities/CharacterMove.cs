using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
 
    private CharacterController _controller;
    private Vector2 _MoveDirection = Vector2.zero;
    private Rigidbody2D _Rigidbody;
    

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _Rigidbody = GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;

    }

    private void FixedUpdate()
    {
        ApplyMove(_MoveDirection);
        UpdateCameraPosition();
    }

    private void Move(Vector2 direction)
    {
        _MoveDirection = direction;
    }

    private void ApplyMove(Vector2 direction)
    {
        direction = direction * 10;
        _Rigidbody.velocity = direction;
    }
    private void UpdateCameraPosition()
    {
    

    }
   
}
