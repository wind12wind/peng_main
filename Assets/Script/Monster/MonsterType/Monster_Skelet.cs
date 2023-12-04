using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Skelet : Monster
{
    private void Awake()
    {
        monsterType = 0;

        maxHp = 10;
        atk = 1;
        speed = 2;

        atkDelay = 5;

        level = 1;

        isAttacking = false;

    }

    void Start()
    {
        isDead = false;
        currentHp = maxHp;
    }

    private void Update()
    {

    }
}
