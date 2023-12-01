using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndPanelUI : MonoBehaviour
{
    public TextMeshProUGUI _bestTimeText { get; set; }
    public TextMeshProUGUI _currentTimeText { get; set; }
    public TextMeshProUGUI _bestKillText { get; set; }
    public TextMeshProUGUI _currentKillText { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        WriteScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void WriteScore()
    {
        _bestTimeText.text = GameManager.Instance.BestAliveTime.ToString("N2");
        _currentTimeText.text = GameManager.Instance.AliveTime.ToString("N2");
        _bestKillText.text = GameManager.Instance.BestKill.ToString();
        _currentKillText.text = GameManager.Instance.Kill.ToString();
    }
}