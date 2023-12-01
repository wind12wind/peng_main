using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopUI : LevelManager
{
    public TextMeshProUGUI _elapsedTimeText;

    public TextMeshProUGUI _levelText;
    public TextMeshProUGUI _remainKillText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTimeText.text = GameManager.Instance.ElapsedTime.ToString("N2");
        _levelText.text = LevelManager.Instance.Level.ToString();
        _remainKillText.text = LevelManager.Instance.RemainKill.ToString();
    }
}
