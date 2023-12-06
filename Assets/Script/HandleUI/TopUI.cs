using UnityEngine;
using TMPro;

public class TopUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentTimeText;

    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _remainTimeText;

    // Update is called once per frame
    void Update()
    {
        _currentTimeText.text = GameManager.Instance.CurrentTime.ToString("N2");
        _levelText.text = MonstersManager.Enemy.Level.ToString();
        _remainTimeText.text = ScoreManager.Score.RemainTime.ToString("N2");
    }
}
