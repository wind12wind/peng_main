using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MonsterMove : MonsterInfo
{
    [SerializeField] private float speed;
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
        // ������ ����
        Vector2 direction = targetPlayer.position - monsterRigidbody.position;
        monsterRigidbody.MovePosition(monsterRigidbody.position + (direction.normalized * speed * Time.fixedDeltaTime));

        monsterRigidbody.velocity = Vector2.zero;
    }

    private void Update()
    {
        // �÷��̾� �������� �Ĵٺ���
        // sprite.flipX = targetPlayer.position.x < 0;
        sprite.flipX = targetPlayer.position.x < monsterRigidbody.position.x;
    }
}
