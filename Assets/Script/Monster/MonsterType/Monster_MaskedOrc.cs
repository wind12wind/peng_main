using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_MaskedOrc : Monster
{
    private void Awake()
    {
        monsterType = 1;
        maxHp = 20;
        speed = 4;
        level = 2;

        bool isLive;

    }
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
