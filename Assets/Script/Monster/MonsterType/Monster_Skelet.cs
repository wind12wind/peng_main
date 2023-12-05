using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Skelet : Monster
{
    private void Awake()
    {
        monsterType = 0;

        Hp = 10;
        speed = 3;
        level = 1;

    }

    void Start()
    {
        isDead = false;
    }

    private void Update()
    {
        if (Hp <= 0)
        {
            MonsterIsDead();
        }
    }
}
