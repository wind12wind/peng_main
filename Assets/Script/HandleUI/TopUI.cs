using UnityEngine;
using TMPro;

public class TopUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentTimeText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _playerHPText;
    [SerializeField] private TextMeshProUGUI _killText;

    [SerializeField] private TextMeshProUGUI _remainTimeText;

    

    // Update is called once per frame
    private void Update()
    {
        _levelText.text = MonstersManager.Enemy.Level.ToString();
        _remainTimeText.text = ScoreManager.Score.RemainTime.ToString("N2");
        _playerHPText.text = Player.Instance.CurrentHp.ToString();
        _killText.text = ScoreManager.Score.Kill.ToString();

        _currentTimeText.text = TimeCalc();
    }

    private string TimeCalc()
    {
        int twoDecimalTime = (int)(GameManager.Instance.CurrentTime * 100);

        int hours = twoDecimalTime / 360000;
        int minutes = (twoDecimalTime % 360000) / 6000;
        int seconds = ((twoDecimalTime % 360000) % 6000) / 100;

        string timeString = $"{hours}:{minutes}:{seconds}";
        return timeString;
    }
}
