using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject Player;
    public GameObject Monster;
    public GameObject Bullet;
    public GameObject Door;

    public GameObject EndPanel;

    [SerializeField] private TextMeshPro _levelText;
    [SerializeField] private Text _currentKillText;
    [SerializeField] private Text _maxKillText;
    [SerializeField] private Text _remainKillText;

    [SerializeField] private Text _elapsedTimeText;

    private int level = 0;
    private float _elapsedTime = 0f;

    private bool _isRunning = true;

    //[SerializeField] private Text DayText;
    //[SerializeField] private Text timeText;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(Instance);
        }

        DontDestroyOnLoad(Instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        //InvokeRepeating("MakeMonster", 0.0f, 1.0f);
        //InvokeRepeating("MakeBullet", 0.0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isRunning)
        {
            _elapsedTime += Time.deltaTime;
            _elapsedTimeText.text = _elapsedTime.ToString("N2");
        }
    }

    //public void MakeBullet()
    //{
    //    float x = Player.transform.position.x;
    //    float y = Player.transform.position.y + 2.0f;
    //    Instantiate(Bullet, new Vector3(x, y, 0), Quaternion.identity);
    //}

    //private void MakeMonster()
    //{
    //    float x = Door.transform.position.x;
    //    float y = Door.transform.position.y;
    //    Instantiate(Monster, new Vector3(x, y, 0), Quaternion.identity);
    //}

    public void GameOver()
    {
        EndPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    //private void MakeTimeStr()
    //{
    //    // convert to DateTime format
    //    DayText.text = DateTime.Now.ToString("yyyy / MM / dd");
    //    timeText.text = DateTime.Now.ToString("HH : mm : ss");
    //}
}
