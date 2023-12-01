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

        level = 2;

    }
    void Start()
    {
        isLive = true;
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
