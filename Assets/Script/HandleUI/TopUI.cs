using UnityEngine;
using TMPro;

public class TopUI : MonoBehaviour
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
        _levelText.text = GameManager.Instance.Score.Level.ToString();
        _remainKillText.text = GameManager.Instance.Score.RemainKill.ToString();
    }
}
