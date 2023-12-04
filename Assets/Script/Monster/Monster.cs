using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] protected int monsterType;

    [SerializeField] protected float maxHp;
    [SerializeField] protected float currentHp;
    [SerializeField] protected int atk;


    protected float delayTime;
    protected float atkDelay;
    public float speed;

    protected int level;

    protected bool isAttacking;
    protected bool isDead;

    private void Awake()
    {

    }
    private void Start()
    {
        currentHp = maxHp;
    }

    protected void IsDead()
    {
        if (maxHp <= 0)
        {
            isDead = true;
        }
    }
}