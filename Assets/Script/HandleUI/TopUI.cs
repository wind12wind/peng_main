using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUI : LevelManager
{
    private TextMeshProUGUI _elapsedTimeText;

    private TextMeshProUGUI _levelText;
    private TextMeshProUGUI _remainKillText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    _elapsedTimeText.text = GameManager.Instance.ElapsedTime.ToString("N2");
    //    _levelText.text = LevelManager.Instance._level.ToString();
    //    _remainKillText.text = _remainKill.ToString();
    //}
}
