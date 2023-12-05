using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private static ResourceManager _resource = new ResourceManager();
    public static ResourceManager Resource
    {
        get
        {
            if (_resource == null)
                _resource = new ResourceManager();

            return _resource;
        }
    }

    private static ScoreManager _score = new ScoreManager(1, 10, 0);
    public static ScoreManager Score
    {
        get
        {
            if (_score == null)
                _score = new ScoreManager(1, 10, 0);

            return _score;
        }
        set
        {
            _score = value;
        }
    }

    private static FieldManager _field = new FieldManager();
    public static FieldManager Field
    {
        get
        {
            if (_field == null)
                _field = new FieldManager();

            return _field;
        }
    }

    public GameObject Player;
    public GameObject Monster;
    public GameObject Bullet;
    public GameObject Door;

    // field for player score
    public float CurrentTime { get; private set; }
    public float BestAliveTime { get; private set; }
    public int BestKill { get; private set; }
    public int Kill { get; private set; }

    public bool IsRunning = true;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if(_instance == null)
        {
            GameObject gameObject = GameObject.Find("GameManager");
            if(gameObject == null )
            {
                gameObject = new GameObject { name = "GameManager" };
                gameObject.AddComponent<GameManager>();
            }
            DontDestroyOnLoad(gameObject);
            _instance = gameObject.GetComponent<GameManager>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = 0.0f;
        Kill = 0;
        IsRunning = true;

        Time.timeScale = 1.0f;

        _resource.Instantiate("TopUI");
        _field.CreateTileMap("Field");

        //InvokeRepeating("MakeMonster", 0.0f, 2.0f);
        //InvokeRepeating("MakeBullet", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRunning)
        {
            CurrentTime += Time.deltaTime;
        }

        //test for GameOver()
        if ((CurrentTime > 60.0f) && _isRunning)
        {
            GameOver();
        }
    }

    //test for bullet instantiate
    public void MakeBullet()
    {
        float x = Player.transform.position.x;
        float y = Player.transform.position.y + 2.0f;
        Instantiate(Bullet, new Vector3(x, y, 0), Quaternion.identity);
    }

    //test for monster instantiate
    public void MakeMonster()
    {
        float x = Door.transform.position.x;
        float y = Door.transform.position.y;
        Instantiate(Monster, new Vector3(x, y, 0), Quaternion.identity);
    }

    public void GameOver()
    {
        BestAliveTime = (BestAliveTime > CurrentTime) ? BestAliveTime : CurrentTime;
        Kill = _score.Kill;
        BestKill = (BestKill > Kill) ? BestKill : Kill;

        _resource.Instantiate("EndPanel");

        Time.timeScale = 0.0f;
        IsRunning = false;
    }
}
