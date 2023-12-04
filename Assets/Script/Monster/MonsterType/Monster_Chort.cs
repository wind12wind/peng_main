using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Chort : Monster
{

    private void Awake()
    {
        monsterType = 2;

        maxHp = 30;
        atk = 3;
        speed = 4;

        atkDelay = 7;

        level = 3;

        isAttacking = false;

    }
    void Start()
    {
        isDead = false ;
        currentHp = maxHp;
    }

    private void Update()
    {

    }
}
