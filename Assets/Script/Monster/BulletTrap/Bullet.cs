using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Player _player = new Player();

    public int bulletAtk;
    [SerializeField] protected float bulletSpeed;

    float DesBullet;

    void Start()
    {
        DesBullet = GameManager.Instance.CurrentTime;
    }

    void Update()
    {
        if (GameManager.Instance.CurrentTime > 10f + DesBullet)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            HitDamage();
            Destroy(gameObject);
        }
        Debug.Log($"HP가 {_player.currentHp} 만큼 남았어!");
    }

    void HitDamage()
    {
        _player.currentHp -= bulletAtk;
    }
}
