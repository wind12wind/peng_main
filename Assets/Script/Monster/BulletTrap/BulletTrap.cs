using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrap : MonoBehaviour
{
    public static BulletTrap _bulletTrap;

    [SerializeField] private GameObject[] bullets;
    [SerializeField] private Transform[] bulletPositions;
    [SerializeField] private Bullet[] bulletLevel;

    [SerializeField] private Transform playerPos;

    private Rigidbody2D _bulletRigid;

    private float[] attackTimes = { 1f, 2f, 2.5f, 3f };
    private float[] attackDelays = { 0f, 0f, 0f, 0f };

    public int currentLevel = 1;

    private void Awake()
    {
        Invoke("LevelUp", 10f);
        Invoke("LevelUp", 20f);
        Invoke("LevelUp", 30f);
        Invoke("LevelUp", 40f);
    }

    void Start()
    {

    }

    void Update()
    {
        for (int i = 0; i < attackTimes.Length; i++)
        {
            attackDelays[i] += Time.deltaTime;

            if (attackDelays[i] >= attackTimes[i] && currentLevel >= i + 1)
            {
                ShootBullet(i + 1);
                attackDelays[i] = 0f;
            }
        }
    }
    void ShootBullet(int level)
    {
        float bulletSpeed = bulletLevel[level - 1].speed;
        float bulletAtk = bulletLevel[level - 1].atk;

        GameObject bullet = Instantiate(bullets[level -1], bulletPositions[level -1].position, Quaternion.identity);
        _bulletRigid = bullet.GetComponent<Rigidbody2D>();

        Vector2 direction = (Vector2)playerPos.position - (Vector2)bulletPositions[level -1].position;
        direction.Normalize();

        _bulletRigid.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
        _bulletRigid.transform.parent = transform;
    }

    void LevelUp()
    {
        currentLevel++;
    }
}
