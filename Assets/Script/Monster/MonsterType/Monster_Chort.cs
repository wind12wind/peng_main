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

        level = 3;

    }
    void Start()
    {
        isLive = true;
        currentHp = maxHp;
    }
}
