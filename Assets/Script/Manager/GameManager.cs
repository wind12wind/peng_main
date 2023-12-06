using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public static GameManager Instance { get { return _instance; } set { _instance = value; } }

    // ResourceManager Singleton
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

    // ScoreManager Singleton
    private static ScoreManager _score = new ScoreManager(10, 0);
    public static ScoreManager Score
    {
        get
        {
            if (_score == null)
                _score = new ScoreManager(10, 0);

            return _score;
        }
        set
        {
            _score = value;
        }
    }

    // FieldManager Singleton
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

    // field for test
    public GameObject Player;
    public GameObject Monster;
    public GameObject Bullet;
    public GameObject Door;

    // field for player score
    public float CurrentTime { get; set; }
    public float BestAliveTime { get; private set; }
    public int BestKill { get; private set; }
    public int Kill { get; set; }

    // field for game run
    public bool IsRunning { get; set; }
    private GameController _controller;

    // GameManager Singleton
    private void Init()
    {
        if(_instance == null)
        {
            GameObject gameObject = GameObject.FindGameObjectWithTag("GameManager");
            if(gameObject == null )
            {
                gameObject = new GameObject { name = "GameManager" };
                gameObject.AddComponent<GameManager>();
            }
            DontDestroyOnLoad(gameObject);
            _instance = gameObject.GetComponent<GameManager>();
        }
    }

    private void Awake()
    {
        Init();
        _controller = GetComponent<GameController>();
        Resource.Instantiate("Prefabs", "Character");
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = 0.0f;
        Kill = 0;
        IsRunning = true;

        Time.timeScale = 1.0f;

        _resource.Instantiate("Prefabs", "TopUI");
        _field.CreateTileMap("Field");

        _controller.OnRetryEvent += RetryGame;
        _controller.OnPauseEvent += PauseGame;
        _controller.OnResumeEvent += ResumeGame;

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
        if ((CurrentTime > 15.0f) && IsRunning)
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

        _resource.Instantiate("Prefabs", "EndPanel");

        Time.timeScale = 0.0f;
        IsRunning = false;
    }

    //re-init game data for new game
    public void RetryGame()
    {
        //Debug.Log("RetryGame");
        SceneManager.LoadScene("SampleScene");
        Resource.Instantiate("Prefabs", "Character");

        _instance.CurrentTime = 0.0f;
        _instance.Kill = 0;
        Time.timeScale = 1.0f;
        _instance.IsRunning = true;
    }

    private void PauseGame()
    {
        //Debug.Log("PauseGame");
        Time.timeScale = 0.0f;
    }

    private void ResumeGame()
    {
        //Debug.Log("ResumeGame");
        Time.timeScale = 1.0f;
    }
}
