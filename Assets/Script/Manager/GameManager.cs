using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private FieldManager _field;
    private ResourceManager _resource;
    private ScoreManager _score;
    public ResourceManager Resource { get { return _resource; } }
    public ScoreManager Score { get { return _score; } set { _score = value; } }

    public GameObject Player;
    public GameObject Monster;
    public GameObject Bullet;
    public GameObject Door;

    // field for EndPanel
    [SerializeField] private GameObject EndPanel;

    // field for player score
    public float CurrentTime { get; private set; }
    public float BestAliveTime { get; private set; }
    public int BestKill { get; private set; }
    public int Kill { get; private set; }

    public bool IsRunning = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(Instance);
        }

        DontDestroyOnLoad(Instance);

        _resource.Instantiate("Prefabs/ResourceManager");

        _resource.Instantiate("Prefabs/LevelManager");

        GameObject topUI = _resource.Instantiate("Prefabs/TopUI");
        topUI.transform.position = new Vector3(0, 0, 0);

        _field.CreateTileMap("Prefabs/Field");
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = 0.0f;
        Kill = 0;
        IsRunning = true;

        Time.timeScale = 1.0f;
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
        if ((CurrentTime > 30.0f) && IsRunning)
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

        _resource.Instantiate("Prefabs/EndPanel");

        Time.timeScale = 0.0f;
        IsRunning = false;
    }
}
