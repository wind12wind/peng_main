using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MtonsterList : MonoBehaviour
{
    public GameObject[] monsterPrefabs;
    List<GameObject>[] monsters;

    private void Awake()
    {
        monsters = new List<GameObject>[monsterPrefabs.Length];

        for (int monsterList = 0; monsterList < monsterPrefabs.Length; monsterList++)
        {
            monsters[monsterList] = new List<GameObject> ();
        }
    }
}
