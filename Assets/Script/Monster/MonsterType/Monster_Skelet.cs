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

        level = 1;

    }

    void Start()
    {
        isLive = true;
        currentHp = maxHp;
    }
}
