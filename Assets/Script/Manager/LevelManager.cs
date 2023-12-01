using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private GameObject _topUI;

    private int _level = 1;
    private int _remainKill = 0;

    // Start is called before the first frame update
    private void Start()
    {
        this._topUI = GameManager.Resource.Instantiate("TopUI");
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
