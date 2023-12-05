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

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
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
        Instantiate(SnowBall, SnowBallSpawnPosition.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

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
