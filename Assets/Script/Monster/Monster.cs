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

    //protected void IsAttacking()
    //{
    //    GameObject bullet = Instantiate(monsterBullet, transform.position, Quaternion.identity);

    //    Rigidbody2D randomBullet = bullet.GetComponent<Rigidbody2D>();
    //    float angle = Random.Range(0f, 360f);
    //    Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
    //    randomBullet.AddForce(direction * 20f, ForceMode2D.Impulse);

    //    randomBullet.transform.parent = transform;
    //}

}