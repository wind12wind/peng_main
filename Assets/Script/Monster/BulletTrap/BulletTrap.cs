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

    public int currentLevel = 1;

    private void Awake()
    {
        bulletAtk = 0;
        bulletSpeed = 0f;

        Invoke("LevelUp", 10f);
        Invoke("LevelUp", 20f);
        Invoke("LevelUp", 30f);
        Invoke("LevelUp", 40f);
    }

    void Start()
    {
        attackDealy = 0f;
        level1Bullet.SetActive(true);
    }

    void Update()
    {
        attackDealy += Time.deltaTime;
        while (true)
        {
            if (attackDealy >= attackTime)
            {
                if (currentLevel >= 1)
                {
                    BulletLevel1();
                }
                if (currentLevel >= 2)
                {
                    BulletLevel2();
                }
                if (currentLevel >= 3)
                {
                    BulletLevel3();
                }
                if (currentLevel >= 4)
                {
                    BulletLevel4();
                }

            }
            break;
        }
    }

    void BulletLevel1()
    {
        attackDealy = 0f;
        bulletAtk = 5;
        bulletSpeed = 10f;

        GameObject bullet = Instantiate(level1Bullet, level1Pos.position, Quaternion.identity);
      
        Rigidbody2D randomBullet = bullet.GetComponent<Rigidbody2D>();
        float angle = Random.Range(0f, 360f);
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        randomBullet.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);

        randomBullet.transform.parent = transform;
    }

    void BulletLevel2()
    {
        attackDealy = 0f;
        bulletAtk = 7;
        bulletSpeed = 20f;

        GameObject bullet = Instantiate(level2Bullet, level2Pos.position, Quaternion.identity);

        Rigidbody2D randomBullet = bullet.GetComponent<Rigidbody2D>();
        float angle = Random.Range(0f, 360f);
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        randomBullet.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);

        randomBullet.transform.parent = transform;
    }

    void BulletLevel3()
    {
        attackDealy = 0f;
        bulletAtk = 10;
        bulletSpeed = 30f;

        GameObject bullet = Instantiate(level3Bullet, level3Pos.position, Quaternion.identity);

        Rigidbody2D randomBullet = bullet.GetComponent<Rigidbody2D>();
        float angle = Random.Range(0f, 360f);
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        randomBullet.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);

        randomBullet.transform.parent = transform;
    }

    void BulletLevel4()
    {
        attackDealy = 0f;
        bulletAtk = 15;
        bulletSpeed = 40f;

        GameObject bullet = Instantiate(level4Bullet, level4Pos.position, Quaternion.identity);

        Rigidbody2D randomBullet = bullet.GetComponent<Rigidbody2D>();
        float angle = Random.Range(0f, 360f);
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        randomBullet.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);

        randomBullet.transform.parent = transform;
    }

    void LevelUp()
    {
        currentLevel++;
    }
}
