using UnityEngine;

public class Monster : MonoBehaviour
{
    // 몬스터 정보 

    [SerializeField] protected int monsterType;
    public int Hp;

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
        ScoreManager.Score.AddKill();
    }
    private void OnTriggerEnter2D(Collider2D SnowBall)
    {
        if (SnowBall.CompareTag("SnowBall"))
        {

            int TotalDamage = Player.Instance.atk;
            Hp -= TotalDamage;

            Debug.Log($"체력 {Hp}");

        }

    }


}