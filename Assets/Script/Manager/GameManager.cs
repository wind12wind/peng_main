using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private ResourceManager _resource;

    public static ResourceManager Resource { get { return Instance._resource; } }
    public static LevelManager Score;

    public GameObject Player;
    public GameObject Bullet;
    public GameObject Door;

    // field for EndPanel
    public GameObject EndPanel;

    public float ElapsedTime;
    public float BestAliveTime;
    public float AliveTime;
    public int BestKill;
    public int Kill;

    //field for TopUI
    public GameObject TopUI;

    public 

    public bool _isRunning = true;

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
        ElapsedTime = 0.0f;

        Time.timeScale = 1.0f;
        //InvokeRepeating("MakeMonster", 0.0f, 1.0f);
        //InvokeRepeating("MakeBullet", 0.0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isRunning)
        {
            ElapsedTime += Time.deltaTime;
        }
    }

    //public void MakeBullet()
    //{
    //    float x = Player.transform.position.x;
    //    float y = Player.transform.position.y + 2.0f;
    //    Instantiate(Bullet, new Vector3(x, y, 0), Quaternion.identity);
    //}

    private void MakeMonster()
    {
        float x = Door.transform.position.x;
        float y = Door.transform.position.y;
        Instantiate(Monster, new Vector3(x, y, 0), Quaternion.identity);
    }

    public void GameOver()
    {
        GameObject endPanel = Resources.Load<GameObject>("Prefabs/endPanel");
        Instantiate(endPanel);

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
