using UnityEngine;
using TMPro;

public class EndPanelUI : MonoBehaviour
{
    public static EndPanelUI Instance { get; private set; }

    [SerializeField] private GameObject _EndPanel;

    [SerializeField] private TextMeshProUGUI _bestTimeText;
    [SerializeField] private TextMeshProUGUI _currentTimeText;
    [SerializeField] private TextMeshProUGUI _bestKillText;
    [SerializeField] private TextMeshProUGUI _currentKillText;

    private void Awake()
    {
        //Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        WriteScore();
    }

    private void WriteScore()
    {
        _bestTimeText.text = GameManager.Instance.BestAliveTime.ToString("N2");
        _currentTimeText.text = GameManager.Instance.CurrentTime.ToString("N2");
        _bestKillText.text = GameManager.Instance.BestKill.ToString();
        _currentKillText.text = GameManager.Instance.Kill.ToString();
    }
}