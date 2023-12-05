using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager _enemy;
    public static EnemyManager Enemy { get { return _enemy; } }

    public int Level { get; private set; }

    [SerializeField] private GameObject _player;
    private Rigidbody2D _targetPlayer;
    private Transform _playerPos;

    string[] _monsters = { "Monster_Skelet", "Monster_MaskedOrc", "Monster_Chort" };

    private Transform[] _door = new Transform[6];

    private void Init()
    {
        if (_enemy == null)
        {
            GameObject gameObject = GameObject.FindGameObjectWithTag("EnemyManager");
            if (gameObject == null)
            {
                gameObject = new GameObject { name = "EnemyManager" };
                gameObject.AddComponent<EnemyManager>();
            }
            DontDestroyOnLoad(gameObject);
            _enemy = gameObject.GetComponent<EnemyManager>();
        }
    }

    private void Awake()
    {
        Init();

        _player = GameObject.FindGameObjectWithTag("Character");
        _targetPlayer = _player.GetComponent<Rigidbody2D>();
        _playerPos = _player.GetComponent<Transform>();
        Level = 1;

        _door[0] = GameManager.Resource.Load<Transform>("DoorPosition/Door1");
        _door[0] = GameManager.Resource.Load<GameObject>("DoorPosition/Door1").GetComponent<Transform>();
        _door[1] = GameManager.Resource.Load<GameObject>("DoorPosition/Door2").GetComponent<Transform>();
        _door[2] = GameManager.Resource.Load<GameObject>("DoorPosition/Door3").GetComponent<Transform>();
        _door[3] = GameManager.Resource.Load<GameObject>("DoorPosition/Door4").GetComponent<Transform>();
        _door[4] = GameManager.Resource.Load<GameObject>("DoorPosition/Door5").GetComponent<Transform>();
        _door[5] = GameManager.Resource.Load<GameObject>("DoorPosition/Door6").GetComponent<Transform>();
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

        // 다음 문 개방 애니메이션 (추후 작업)
    }

    // RandomIndex used for select type of monster
    private int GetRandomIndex()
    {
        // 준비된 몬스터의 종류는 3종류이므로 레벨이 올라도 최대 3종류
        int max = (Level > 3) ? 3 : Level;
        int randomIndex = Random.Range(1, max);

        return randomIndex;
    }

    // 몬스터를 특정 문에서 생성, 호출 될 때마다 레벨에 비례해서 내부에서 반복함
    private void MonsterSpawn()
    {
        // 레벨 = 몬스터가 생성되는 문의 갯수
        for (int i = 0; i < Level; i++)
        {
            // 몬스터를 instantiate 할 때마다 무작위 타입으로 지정하여 생성
            GameObject monster = GameManager.Resource.Instantiate( "Prefabs", _monsters[GetRandomIndex()]);

            // 몬스터의 생성 위치를 i번째 문으로 이동
            monster.transform.position = _door[i].position;

            // 몬스터가 추격할 플레이어 캐릭터 지정
            MonsterMove monsterMove = monster.GetComponent<MonsterMove>();
            if (monsterMove != null)
            {
                monsterMove.SetTargetPlayer(_targetPlayer);
            }
        }
    }
}
