using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int Level { get; private set; }
    public int RemainKill { get; private set; }
    public int Kill { get; private set; }

    private void Awake()
    {
        Debug.Log("LevelAwake");
        if (Instance == null)
        {
            Debug.Log("LevelInstantiate");
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.Log("LevelOnlyOne");
            Destroy(Instance);
        }

        DontDestroyOnLoad(Instance);
    }

    // Start is called before the first frame update
    private void Start()
    {
        Level = 1;
        RemainKill = 0;
        Kill = 0;

        Debug.Log("LevelStart");
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
