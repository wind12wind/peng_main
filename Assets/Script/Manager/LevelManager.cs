using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject _topUI;

    private ResourceManager _resource;

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

        _topUI = ResourceManager.Instance.Load<GameObject>("Prefabs/TopUI");
        _topUI = ResourceManager.Instance.Instantiate("TopUI");
        _topUI.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        
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
