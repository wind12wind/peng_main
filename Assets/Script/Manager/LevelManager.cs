using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject _topUI;

    private ResourceManager _resource;

    public static ResourceManager Resource { get { return Instance._resource; } }

    public int Level = 1;
    public int RemainKill = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(Instance);
        }

        DontDestroyOnLoad(Instance);
    }

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("LevelStart");
        this._topUI = LevelManager.Resource.Instantiate("TopUI");
        this._topUI.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void LevelUp()
    {
        this.Level++;
        this.RemainKill = 10;
    }

    // if a monster killed, call this method
    public void SubtractRemain()
    {
        GameManager.Instance.Kill++;
        this.RemainKill--;

        if(RemainKill == 0)
        {
            LevelUp();
        }
    }
}
