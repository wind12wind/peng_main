using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    public GameObject _monsterPrefabs;
    public GameObject _level1Monster;
    public GameObject _level2Monster;

    public Transform _monsterMakePoint;
    //private LevelManager _level = new LevelManager();

    void Start()
    {
        InvokeRepeating("MakeMonster", 2f, 2f);
    }

    void MakeMonster()
    {
                                          // Get 현재레벨 함수();
        // int currentLevel = _level1Monster.GetCurrentLevel();
  
        // 레벨에 따른 몬스터 생성
        //switch (currentLevel)
        //{
        //    case 1:
        //        SpawnMonsterLevel1();
        //        break;
        //    case 2:
        //        SpawnMonsterLevel2();
        //        break;
        //    default:
        //        break;
        //}
        GameObject monster = Instantiate(_monsterPrefabs, _monsterMakePoint.position, Quaternion.identity);
        monster.transform.parent = transform;

        //MonsterMove monsterMove = monster.GetComponent<MonsterMove>();
        //if (monsterMove != null)
        //{
        //    monsterMove.targetPlayer.AddComponent<MonsterMove>();
        //}
    }

    void SpawnMonsterLevel1()
    {
        GameObject monster = Instantiate(_level1Monster, _monsterMakePoint.position, Quaternion.identity);
        monster.transform.parent = transform;
    }

    void SpawnMonsterLevel2()
    {
        GameObject monster = Instantiate(_level2Monster, _monsterMakePoint.position, Quaternion.identity);
        monster.transform.parent = transform;
    }
}
