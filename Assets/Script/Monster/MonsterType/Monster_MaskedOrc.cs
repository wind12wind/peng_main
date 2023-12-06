using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_MaskedOrc : Monster
{
    private void Awake()
    {
        base.Awake();

        monsterType = 1;

        Hp = 20;
        speed = 5;
        level = 2;

    }
    void Start()
    {
        isDead = false;
    }

    private void Update()
    {

    }
}
