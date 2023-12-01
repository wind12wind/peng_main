using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    public GameObject monsterPrefabs;
    public Transform monsterMakePoint;

    void Start()
    {
        InvokeRepeating("MakeMonster", 2f, 2f);

    }

    void MakeMonster()
    {
        GameObject monster = Instantiate(monsterPrefabs, monsterMakePoint.position, Quaternion.identity);
        monster.transform.parent = transform;

        //MonsterMove monsterMove = monster.GetComponent<MonsterMove>();
        //if (monsterMove != null)
        //{
        //    monsterMove.targetPlayer.AddComponent<MonsterMove>();
        //}
    }
}
