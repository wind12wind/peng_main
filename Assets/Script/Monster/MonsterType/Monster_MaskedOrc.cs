using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_MaskedOrc : Monster
{
    private void Awake()
    {
        monsterType = 1;

        maxHp = 20;
        atk = 2;
        speed = 3;

        atkDelay = 6;

        level = 2;

        isAttacking = false;

    }
    void Start()
    {
        isDead = false;
        currentHp = maxHp;
        delayTime = 0;
    }

    private void Update()
    {

    }
}
