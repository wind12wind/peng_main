using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private int _level;
    //private GameObject[] _door = GameObject[7];
    private GameObject _chort;
    private GameObject _maskedOrc;
    private GameObject _skeleton;

    private void Awake()
    {
        _level = GameManager.Score.Level;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
