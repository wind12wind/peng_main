using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndPanelUI : MonoBehaviour
{
    [SerializeField] private GameObject _EndPanel;

    [SerializeField] private TextMeshProUGUI _bestTimeText;
    [SerializeField] private TextMeshProUGUI _currentTimeText;
    [SerializeField] private TextMeshProUGUI _bestKillText;
    [SerializeField] private TextMeshProUGUI _currentKillText;

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
        _currentTimeText.text = GameManager.Instance.CurrentTime.ToString("N2");
        _bestKillText.text = GameManager.Instance.BestKill.ToString();
        _currentKillText.text = GameManager.Instance.Kill.ToString();
    }
}