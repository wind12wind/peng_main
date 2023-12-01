using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int monsterType;

    public float maxHp;
    public float currentHp;
    public float speed;

    public int level;

    bool isLive;

    void Start()
    {
        currentHp = maxHp;
    }

}