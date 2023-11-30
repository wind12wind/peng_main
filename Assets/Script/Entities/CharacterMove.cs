using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private slow _slow;
    private CharacterController _controller;
    private Vector2 _MoveDirection = Vector2.zero;
    private Rigidbody2D _Rigidbody;
    public float normalSpeed = 0.9f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _Rigidbody = GetComponent<Rigidbody2D>();
        _slow = GetComponent<slow>();

    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
      
    }

    private void FixedUpdate()
    {
        ApplyMove(_MoveDirection);
    }

    private void Move(Vector2 direction)
    {
        _MoveDirection = direction;
    }

    private void ApplyMove(Vector2 direction)
    {
        direction = direction * normalSpeed;
        _Rigidbody.velocity = direction;
    }
    public void ApplySlowdown(float slowdownFactor)
    {
        // 물에서의 속도 감소 적용
        _MoveDirection *= slowdownFactor;
    }

    public void ResetSpeed()
    {
        // 속도를 원래대로 복구
        _MoveDirection = _MoveDirection.normalized * normalSpeed;
    }
}
