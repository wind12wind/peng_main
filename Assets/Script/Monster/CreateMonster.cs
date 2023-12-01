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
    private LevelManager _level = new LevelManager();

    void Start()
    {
        InvokeRepeating("MakeMonster", 2f, 2f);
    }

    void MakeMonster()
    {
        switch (_level)
        {
            case 1:
                SpawnMonsterLevel1();
        }
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
