using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public static Rigidbody2D targetPlayer;

    Monster monster;
    SpriteRenderer sprite;
    Rigidbody2D monsterRigidbody;

    public void Awake()
    {
        monsterRigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        monster = GetComponent<Monster>();
    }

    public void FixedUpdate()
    {
        // 몬스터의 이동 방향
        Vector2 direction = targetPlayer.position - monsterRigidbody.position;

        transform.Translate(direction.normalized * monster.speed * Time.fixedDeltaTime);
        monsterRigidbody.velocity = Vector2.zero;
    }

    public void Update()
    {
        // 플레이어 방향으로 쳐다보기
        sprite.flipX = targetPlayer.position.x < 0;
    }

    public void SetTargetPlayer(Rigidbody2D player)
    {
        targetPlayer = player;
    }
}
