using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public int Atk;
    public int CurrentHp;
    public int CurrentMp;

    private int maxHp;
    private int maxMp;

    private bool isDead;
    public bool doubleShot;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Atk = 10;
        maxHp = 100;
        CurrentHp = 100;
        maxMp = 100;
        CurrentMp = 30;
        isDead = false;
    }

    // BulletTrap과 충돌했을 때 발생
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletTrap"))
        {
            if (CurrentHp <= 0)
            {
                CurrentHp = 0;
                isDead = true;
                PlayerIsDead();
            }
        }
    }

    // 플레이어 사망 시
    private void PlayerIsDead()
    {
        GameManager.Instance.GameOver();
    }

    public void PlusAtk()
    {
        Atk += 5;
        Debug.Log($"플레이어의 현재 공격력 {Atk}");
    }

    public void DoubleShotOn()
    {
        doubleShot = true;
    }
}
