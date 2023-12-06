using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private Transform SnowBallSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;
    [SerializeField] private SpriteRenderer characterRenderer;

    public GameObject SnowBall;
    private Rigidbody2D SnowBallRigid;
    private float SnowBallSpeed = 10f;
    private Transform SnowBalls;


    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        SnowBalls = new GameObject("SnowBalls").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
        _controller.OnMoveEvent += OnMoveRotation;

    }

    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;
    }

    private void OnShoot()
    {
        CreateSnowBall();
    }

    private void CreateSnowBall()
    {
        GameObject SnowBallObject = Instantiate(SnowBall, SnowBallSpawnPosition.position, Quaternion.identity,SnowBalls);
        SnowBallRigid = SnowBallObject.GetComponent<Rigidbody2D>();
        if(SnowBallRigid != null)
        {
            SnowBallRigid.velocity = _aimDirection.normalized * SnowBallSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        //방향 , 마우스포인트 값, 객체에 스크립트 생성
        //벡터 포워드

    }

    private void OnMoveRotation(Vector2 newMoveDirection)
    {
        RotateCharacter(newMoveDirection);
    }

    private void RotateCharacter(Vector2 direction)
    {

        if (direction.x != 0)
        {
            characterRenderer.flipX = direction.x < 0;
        }
    }
}

