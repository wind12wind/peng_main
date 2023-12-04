using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    [SerializeField] private GameObject _level1Monster;
    [SerializeField] private GameObject _level2Monster;
    [SerializeField] private GameObject _level3Monster;

    [SerializeField] private Transform _monsterLevel1MakePoint;
    [SerializeField] private Transform _monsterLevel2MakePoint;
    [SerializeField] private Transform _monsterLevel3MakePoint;

    private int currentLevel = 1;
    private bool spawnEnabled = true;

    //private LevelManager _level = new LevelManager();

    private void Awake()
    {

    }
    void Start()
    {
        Invoke("LevelUp", 5f);

        InvokeRepeating("MakeMonsterLevel1", 2f, 2f);
        _level1Monster.SetActive(true);
    }

    private void Update()
    {

        if (currentLevel >= 2 && spawnEnabled)
        {
            //Invoke("SpawnMonsterLevel2", 2f);
            Debug.Log("2레벨 몬스터가 등장합니다");
            //Invoke("MakeMonsterLevel2", 2f);
            InvokeRepeating("SpawnMonsterLevel2", 4f, 4f);

            _level2Monster.SetActive(true);
            spawnEnabled = false;
        }
        else if (currentLevel >= 3 && spawnEnabled)
        {

        }

    }

    void MakeMonsterLevel1()
    {
        SpawnMonsterLevel1();
        Debug.Log("1레벨 소환");
    }

    void MakeMonsterLevel2()
    {
        InvokeRepeating("SpawnMonsterLevel2", 0f, 3f);
    }

    void LevelUp()
    {
        Debug.Log("레벨업");
        currentLevel++;
        Debug.Log(currentLevel);
    }
    void SpawnMonsterLevel1()
    {
        GameObject monster = Instantiate(_level1Monster, _monsterLevel1MakePoint.position, Quaternion.identity);
        monster.transform.parent = transform;
    }

    void SpawnMonsterLevel2()
    {
        Debug.Log("2레벨 소환");
        GameObject monster = Instantiate(_level2Monster, _monsterLevel2MakePoint.position, Quaternion.identity);
        monster.transform.parent = transform;
    }
}