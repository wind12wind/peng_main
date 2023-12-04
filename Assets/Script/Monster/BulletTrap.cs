using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrap : Bullet
{
    [SerializeField] private Transform targetPlayer;

    [SerializeField] private GameObject level1Bullet;
    [SerializeField] private GameObject level2Bullet;
    [SerializeField] private GameObject level3Bullet;
    [SerializeField] private GameObject level4Bullet;

    [SerializeField] private Transform level1Pos;
    [SerializeField] private Transform level2Pos;
    [SerializeField] private Transform level3Pos;
    [SerializeField] private Transform level4Pos;

    public Rigidbody2D bulletRigid;
    Transform playerPos;

    private float attackTime = 2f;
    private float attackDealy;

    private void Awake()
    {
        
    }

    void Start()
    {
        attackDealy = 0f;
        level1Bullet.SetActive(true);
    }

    void Update()
    {
        attackDealy += Time.deltaTime;

        if(attackDealy >= attackTime)
        {
            attackDealy = 0f;
            
            GameObject bullet = Instantiate(level1Bullet, level1Pos.position, Quaternion.identity);
            atk = 10;
            speed = 10;

            Rigidbody2D randomBullet = bullet.GetComponent<Rigidbody2D>();
            float angle = Random.Range(0f, 360f);
            Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            randomBullet.AddForce(direction * speed, ForceMode2D.Impulse);

            randomBullet.transform.parent = transform;
        }
    }
}
