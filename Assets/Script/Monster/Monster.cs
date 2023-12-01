using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected int monsterType;

    protected float maxHp;
    protected float currentHp;
    protected int atk;
    public float speed;

    protected int level;

    protected bool isLive;

    void Start()
    {
        currentHp = maxHp;
    }



}