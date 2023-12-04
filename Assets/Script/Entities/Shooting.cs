using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private Transform SnowBallSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;

    public GameObject SnowBall;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;

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
        Instantiate(SnowBall, SnowBallSpawnPosition.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //투사체가 앞으로 나아가는 로직
        //방향 , 마우스포인트 값, 객체에 스크립트 생성
        //벡터 포워드
    }


}