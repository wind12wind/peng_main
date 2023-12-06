using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Score { get; private set; }

    public float RemainTime { get; private set; }
    public int Kill { get; private set; }

    private int _level = 1;

    // variables for PlayerPrefs Key
    private const string BestAliveTimeKey = "BestAliveTime";
    private const string BestKillKey = "BestKill";

    private void Awake()
    {
        //Singleton
        if (Score == null)
        {
            Score = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Kill = 0;
        RemainTime = 10.0f;

        GameObject topUI = Resources.Load<GameObject>("ManagerAndUI/TopUI");
        Instantiate(topUI, null);
    }

    // stage level up every 10 seconds
    private void Update()
    {
        if(RemainTime > 0.0f)
        {
            RemainTime -= Time.deltaTime;

            if ((RemainTime <= 0f) && (_level < 6))
            {
                _level++;
                RemainTime = 10.0f;
                MonstersManager.Enemy.LevelUp();
            }
            else if(_level >= 6)
            {
                RemainTime = 0.0f;
            }
        }
    }

    public float LoadBestAliveTime()
    {
        return PlayerPrefs.GetFloat(BestAliveTimeKey);
    }

    public void SaveBestAliveTime()
    {
        float time = GameManager.Instance.CurrentTime;

        if (LoadBestAliveTime() < time)
        {
            PlayerPrefs.SetFloat(BestAliveTimeKey, time);
        }
    }

    public int LoadBestKill()
    {
        return PlayerPrefs.GetInt(BestKillKey);
    }

    public void SaveBestKill()
    {
        if (LoadBestKill() < Kill)
        {
            PlayerPrefs.SetInt(BestKillKey, Kill);
        }
    }

    // if a monster killed, call this method
    public void AddKill()
    {
        Kill++;
    }

    public void InitBestScore()
    {
        PlayerPrefs.SetFloat(BestAliveTimeKey, 0.0f);
        PlayerPrefs.SetInt(BestKillKey, 0);
    }

    public void ResetKill()
    {
        Kill = 0;
        _level = 1;
        RemainTime = 10.0f;
    }
}
