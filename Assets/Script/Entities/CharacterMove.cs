using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private slow _slow;
    private CharacterController _controller;
    private Vector2 _MoveDirection = Vector2.zero; 
    public float _Speed = 1f;
    private Rigidbody2D _Rigidbody;
    public static float normalSpeed = 9.0f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _Rigidbody = GetComponent<Rigidbody2D>();
        _slow = GetComponent<slow>();

    }

    private void Start()
    {
        _controller.OnMoveEvent += ApplyMove;
      
    }

    private void FixedUpdate()
    {
        ApplyMove(_MoveDirection);
    }

    //private void Move(Vector2 direction)
    //{
    //    _MoveDirection = direction;
    //    if (_slow != null && _slow.IsPlayerStillInWater())
    //    {
    //        _Rigidbody.velocity = direction * _slow.slowdownFactor;
    //    }
    //    else
    //    {
    //        _Rigidbody.velocity = direction;
    //    }
    //}

    private void ApplyMove(Vector2 direction)
    {
        _MoveDirection = direction;
        direction = direction * normalSpeed * _Speed;
        _Rigidbody.velocity = direction;
    }
    public void ApplySlowdown(float slowdownFactor)
    {
        // 물에서의 속도 감소 적용
        _Speed = slowdownFactor; //변화되는 장소를 찾아서 확인해보자.
    }

    public void ResetSpeed()
    {
        // 속도를 원래대로 복구
        _Speed = 1f;
    }
}
