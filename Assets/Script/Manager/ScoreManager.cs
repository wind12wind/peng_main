using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Score { get; private set; }

    public float RemainTime { get; private set; }
    public int Kill { get; private set; }

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
        RemainTime -= Time.deltaTime;

        if(RemainTime <= 0f)
        {
            RemainTime = 10.0f;
            MonstersManager.Enemy.LevelUp();
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
}
