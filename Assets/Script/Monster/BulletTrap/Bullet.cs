using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int atk;
    public float speed;

    float DesBullet;

    void Start()
    {
        DesBullet = GameManager.Instance.CurrentTime;
    }

    void Update()
    {
        if (GameManager.Instance.CurrentTime > 16f + DesBullet)
        {
            Destroy(gameObject);
        }
    }

    // Player와 충돌 했을 때
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            
            if (player != null)
            {
                player.CurrentHp -= atk;
                Destroy(gameObject);
                Debug.Log($"HP가 {player.CurrentHp} 만큼 남았어!");
            }
        }
    }
}
