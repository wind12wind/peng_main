using UnityEngine;
using TMPro;

public class TopUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentTimeText;

    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _remainKillText;

    // Update is called once per frame
    void Update()
    {
        _currentTimeText.text = GameManager.Instance.CurrentTime.ToString("N2");
        _levelText.text = GameManager.Score.Level.ToString();
        _remainKillText.text = GameManager.Score.RemainKill.ToString();
    }
}
