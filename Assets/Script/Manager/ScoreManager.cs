using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Level { get; private set; }
    public int RemainKill { get; private set; }
    public int Kill { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        Level = 1;
        RemainKill = 0;
        Kill = 0;

        Debug.Log("ScoreStart");
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
