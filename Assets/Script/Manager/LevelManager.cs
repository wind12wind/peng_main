using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject levelUI;

    public int _level = 1;
    private int _remainKill = 0;

    // Start is called before the first frame update
    private void Start()
    {
        levelUI = GameManager.Resource.Instantiate("LevelUI");
        levelUI.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void LevelUp()
    {
        _level++;
        _remainKill = 10;
    }

    // if a monster killed, call this method
    public void SubtractRemain()
    {
        GameManager.Instance.Kill++;
        _remainKill--;

        if(_remainKill == 0)
        {
            LevelUp();
        }
    }
}
