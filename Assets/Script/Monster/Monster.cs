using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] protected int monsterType;

    [SerializeField] protected float maxHp;
    [SerializeField] protected float currentHp;
    [SerializeField] protected int atk;
    public float speed;

    protected int level;

    protected bool isLive;

    void Start()
    {
        currentHp = maxHp;
    }



}