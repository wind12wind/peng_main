using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopUI : LevelManager
{
    [SerializeField] private TextMeshProUGUI _currentTimeText;

    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _remainKillText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _currentTimeText.text = GameManager.Instance.CurrentTime.ToString("N2");
        _levelText.text = LevelManager.Instance.Level.ToString();
        _remainKillText.text = LevelManager.Instance.RemainKill.ToString();
    }
}
