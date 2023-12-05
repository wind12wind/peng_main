using UnityEngine;

public class ScoreManager
{
    public int Level { get; private set; }
    public int RemainKill { get; private set; }
    public int Kill { get; private set; }

    // Start is called before the first frame update
    public ScoreManager(int level, int remainKill, int kill)
    {
        Level = level;
        RemainKill = remainKill;
        Kill = kill;
    }

    private void LevelUp()
    {
        Debug.Log("LevelUp");
        this.Level++;
        this.RemainKill = 10;
    }

    // if a monster killed, call this method
    public void SubtractRemain()
    {
        Debug.Log("AddKill");
        Kill++;
        RemainKill--;

        if(RemainKill == 0)
        {
            LevelUp();
        }
    }
}
