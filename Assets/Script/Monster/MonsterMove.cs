using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MonsterMove : MonsterInfo
{
    [SerializeField] private float moveSpeed;
    public Rigidbody2D targetPlayer;

    SpriteRenderer sprite;
    Rigidbody2D monsterRigidbody;
    

    private void Awake()
    {
        monsterRigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    { 
        // 몬스터의 방향
        Vector2 direction = targetPlayer.position - monsterRigidbody.position;
        monsterRigidbody.MovePosition(monsterRigidbody.position + (direction.normalized * moveSpeed * Time.fixedDeltaTime));

        monsterRigidbody.velocity = Vector2.zero;
    }

    private void Update()
    {
        // 플레이어 방향으로 쳐다보기
        // sprite.flipX = targetPlayer.position.x < 0;
        sprite.flipX = targetPlayer.position.x < monsterRigidbody.position.x;
    }
}
