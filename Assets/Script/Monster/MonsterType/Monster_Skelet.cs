using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Skelet : Monster
{
    private void Awake()
    {
        monsterType = 0;
        maxHp = 10;
        speed = 2;
        level = 1;

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
