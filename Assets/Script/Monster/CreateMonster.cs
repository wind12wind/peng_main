using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class CreateMonster : Monster
{

    [SerializeField] private GameObject _level1Monster;
    [SerializeField] private GameObject _level2Monster;
    [SerializeField] private GameObject _level3Monster;

    [SerializeField] private Transform _monsterLevel1MakePoint;
    [SerializeField] private Transform _monsterLevel2MakePoint;
    [SerializeField] private Transform _monsterLevel3MakePoint;

    private int currentLevel = 1;
    private bool spawnEnabled = false;

    //private LevelManager _level = new LevelManager();

    private void Awake()
    {

    }
    void Start()
    {
        Invoke("LevelUp", 5f);

        InvokeRepeating("SpawnMonsterLevel1", 2f, 2f);
        _level1Monster.SetActive(true);

        Invoke("LevelUp2", 10f);
    }

    private void Update()
    {
        while (true)
        {
            if (currentLevel == 2 && spawnEnabled)
            {
                Debug.Log("2레벨 몬스터가 등장합니다");
                InvokeRepeating("SpawnMonsterLevel2", 4f, 4f);
                _level2Monster.SetActive(true);
                spawnEnabled = false;
                break;
            }
            if (currentLevel >= 3 && spawnEnabled)
            {
                Debug.Log("3레벨 몬스터가 등장합니다");
                InvokeRepeating("SpawnMonsterLevel3", 6f, 6f);
                _level3Monster.SetActive(true);
                spawnEnabled = false;
                break;
            }
            break;
        }
    }

    void MakeMonsterLevel1()
    {
        SpawnMonsterLevel1();
        Debug.Log("Level 1 Monster");
    }

    //void MakeMonsterLevel2()
    //{
    //    InvokeRepeating("SpawnMonsterLevel2", 0f, 4f);
    //}
    //void MakeMonsterLevel3()
    //{
    //    InvokeRepeating("SpawnMonsterLevel3", 0f, 6f);
    //}

    void LevelUp()
    {
        Debug.Log("LevelUp + 1");
        currentLevel++;
        Debug.Log(currentLevel);
        spawnEnabled = true;
    }
    void LevelUp2()
    {
        Debug.Log("LevelUp + 3");
        currentLevel++;
        currentLevel++;
        currentLevel++;
        Debug.Log(currentLevel);
        spawnEnabled = true;
    }
    void SpawnMonsterLevel1()
    {
        GameObject monster = Instantiate(_level1Monster, _monsterLevel1MakePoint.position, Quaternion.identity);
        monster.transform.parent = transform;
    }

    void SpawnMonsterLevel2()
    {
        GameObject monster = Instantiate(_level2Monster, _monsterLevel2MakePoint.position, Quaternion.identity);
        monster.transform.parent = transform;
        Debug.Log("Level2 Monster");
    }

    void SpawnMonsterLevel3()
    {
        GameObject monster = Instantiate(_level3Monster, _monsterLevel3MakePoint.position, Quaternion.identity);
        monster.transform.parent = transform;
        Debug.Log("Level3 Monster");
    }
}