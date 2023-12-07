using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // GameManager Singleton
    public static GameManager Instance { get; private set; }

    //[SerializeField] private GameObject _Managers;
    [SerializeField] private GameObject _Managers;

    // field for player score
    public float CurrentTime { get; set; }
    public float BestAliveTime { get; private set; }
    public int BestKill { get; private set; }
    public int Kill { get; set; }

    // field for game run
    public bool IsRunning { get; set; }
    private GameController _controller;

    private void Awake()
    {
        _Managers = GameObject.FindGameObjectWithTag("Managers");

        //Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            DontDestroyOnLoad(_Managers);
        }
        else
        {
            Destroy(gameObject);
        }

        //using pause, resume, retry
        _controller = GetComponent<GameController>();
        GameObject score = Resources.Load<GameObject>("ManagerAndUI/ScoreManager");
        Instantiate(score, _Managers.transform);


        GameObject field = Resources.Load<GameObject>("ManagerAndUI/FieldManager");
        Instantiate(field, _Managers.transform);

        GameObject enemy = Resources.Load<GameObject>("ManagerAndUI/MonstersManager");
        Instantiate(enemy);

        GameObject bulletTrap = Resources.Load<GameObject>("Prefabs/Bullets/BulletTrap");
        Instantiate(bulletTrap);
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = 0.0f;
        Kill = 0;
        IsRunning = true;

        Time.timeScale = 1.0f;

        _controller.OnRetryEvent += RetryGame;
        _controller.OnPauseEvent += PauseGame;
        _controller.OnResumeEvent += ResumeGame;
        _controller.OnInitBestScoreKeyEvent += InitBestScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRunning)
        {
            CurrentTime += Time.deltaTime;
        }
    }

    public void GameOver()
    {
        //Debug.Log("GameOver");

        ScoreManager.Score.SaveBestAliveTime();
        ScoreManager.Score.SaveBestKill();

        Kill = ScoreManager.Score.Kill;
        BestAliveTime = ScoreManager.Score.LoadBestAliveTime();
        BestKill = ScoreManager.Score.LoadBestKill();

        GameObject endPanel = Resources.Load<GameObject>("ManagerAndUI/EndPanel");
        Instantiate(endPanel);

        Time.timeScale = 0.0f;
        IsRunning = false;
    }

    //re-init game data for new game
    public void RetryGame()
    {
        //Debug.Log("RetryGame");
        SceneManager.LoadScene("SampleScene");
        ScoreManager.Score.ResetKill();

        CurrentTime = 0.0f;
        Kill = 0;
        Time.timeScale = 1.0f;
        IsRunning = true;
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

    private void InitBestScore()
    {
        ScoreManager.Score.InitBestScore();
    }
}
