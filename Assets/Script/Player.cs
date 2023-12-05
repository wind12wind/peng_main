using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Player : MonoBehaviour
{
    public static Player _player;

    private int atk;
    private int maxHp;
    public int currentHp;
    private int maxMp;
    private int currentMp;

    private bool isDead;

    private void Awake()
    {
        atk = 10;
        maxHp = 100;
        currentHp = 30;
        maxMp = 100;
        currentMp = 100;

        isDead = false;
    }

    void Start()
    {

    }


    void Update()
    {
        if (isDead)
        {
            PlayerIsDead();
        }
    }

    // BulletTrap과 충돌했을 때 발생
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletTrap"))
        {
            if (currentHp <= 0)
            {
                isDead = true;
            }
        }
    }

    // 플레이어 사망 시
    private void PlayerIsDead()
    {
        GameManager.Instance.GameOver();
    }
}
