using UnityEngine;

public class Monster : MonoBehaviour
{
    public static Monster Instance;

    // 몬스터 정보
    [SerializeField] protected int monsterType;
    public int Hp;
    public float speed;

    protected int level;
    public bool isDead;
    protected Animator animator;

    protected void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {

    }

    protected void MonsterIsDead()
    { 
        isDead = true;
        gameObject.tag = "Untagged";
        animator.SetBool("IsDead", true);
        Destroy(gameObject, 1f);
		ScoreManager.Score.AddKill();
    }

    private void OnTriggerEnter2D(Collider2D SnowBall)
    {
        if (SnowBall.CompareTag("SnowBall"))
        {

            int TotalDamage = Player.Instance.Atk;
            Hp -= TotalDamage;

            Debug.Log($"체력 {Hp}");

            if (Hp<= 0 && !isDead)
            {
                speed = 0f;
                MonsterIsDead();
            }
        }
    }
}