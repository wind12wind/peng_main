using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // 몬스터 정보 

    [SerializeField] protected int monsterType;
    [SerializeField] protected int Hp;

    public float speed;

    protected int level;

    protected bool isDead;

    private void Awake()
    {

    }
    private void Start()
    {

    }

    protected void MonsterIsDead()
    {
        isDead = true;
        Destroy(gameObject);
    }
}