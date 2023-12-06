using UnityEngine;

public class MonstersManager : MonoBehaviour
{
    public static MonstersManager Enemy { get; private set; }

    public int Level { get; private set; }

    [SerializeField] private GameObject _player;
    private Rigidbody2D _targetPlayer;

    string[] _monsters = { "Monster_Skelet", "Monster_MaskedOrc", "Monster_Chort" };

    private Transform[] _door = new Transform[6];

    private void Awake()
    {
        //Singleton
        if (Enemy == null)
        {
            Enemy = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _player = GameObject.FindGameObjectWithTag("Character");
        _targetPlayer = _player.GetComponent<Rigidbody2D>();
        
        Level = 1;

        for (int i = 0; i < _door.Length; i++)
        {
            _door[i] = Resources.Load<Transform>($"DoorPosition/Door{i+1}");
        }
    }

    private void Start()
    {
        InvokeRepeating("MonsterSpawn", 2f, 2f);
    }

    /// <summary>
    /// ScoreManager에서 10킬 할 때마다 레벨 1씩 증가, 최대 6레벨
    /// 그 이상은 문의 갯수나 몬스터 종류에 변화가 없어서 무의미함
    /// </summary>
    public void LevelUp()
    {
        // max level == 6, max door open == 6
        if (Level < 6)
        {
            Level++;
        }

        BulletTrap.BulletTrapInstance.CurrentLevel();

        // 다음 문 개방 애니메이션 (추후 작업)
    }

    // RandomIndex used for select type of monster
    private int GetRandomIndex()
    {
        // 준비된 몬스터의 종류는 3종류이므로 레벨이 올라도 최대 3종류
        int max = (Level > 3) ? 3 : Level;
        int randomIndex = Random.Range(0, max);

        return randomIndex;
    }

    // 몬스터를 특정 문에서 생성, 호출 될 때마다 레벨에 비례해서 내부에서 반복함
    private void MonsterSpawn()
    {
        // 레벨 = 몬스터가 생성되는 문의 갯수
        for (int i = 0; i < Level; i++)
        {
            // 몬스터를 instantiate 할 때마다 무작위 타입으로 지정하여 각각의 문에 생성
            GameObject monster = Resources.Load<GameObject>($"Prefabs/{_monsters[GetRandomIndex()]}");
            Instantiate(monster, _door[i].position, Quaternion.identity, transform);

            // 몬스터가 추격할 플레이어 캐릭터 지정
            MonsterMove monsterMove = monster.GetComponent<MonsterMove>();
            if (monsterMove != null)
            {
                monsterMove.SetTargetPlayer(_targetPlayer);
            }
        }
    }
}
