using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Score { get; private set; }

    public int RemainKill { get; private set; }
    public int Kill { get; private set; }

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
        RemainKill = 10;

        GameObject topUI = Resources.Load<GameObject>("ManagerAndUI/TopUI");
        Instantiate(topUI, null);
    }

    //test code
    private void Start()
    {
        InvokeRepeating("ForceKillUp", 1f, 1f);
    }

    private void ForceKillUp()
    {
        SubtractRemain();
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
    public void SubtractRemain()
    {
        Kill++;

        if (RemainKill != 0)
        {
            RemainKill--;
            //Debug.Log($"Kill Added, remain Kill = {RemainKill}");
        }
        if ( (RemainKill == 0) && (MonstersManager.Enemy.Level < 6) )
        {
            RemainKill = 10;
            MonstersManager.Enemy.LevelUp();
        }
    }
}
