using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    [SerializeField] private GameObject _level1Monster;
    [SerializeField] private GameObject _level2Monster;

    [SerializeField] private Transform _monsterLevel1MakePoint;
    [SerializeField] private Transform _monsterLevel2MakePoint;


    private int currentLevel = 1;
    private float delayTimeLevel1 = 1f;
    private float delayTimeLevel2 = 2f;


    //private LevelManager _level = new LevelManager();

    private void Awake()
    {
        InvokeRepeating("LevelUp", 5f, 5f);
    }

    void Start()
    {
        _level2Monster.SetActive(false);

        StartCoroutine(MakeMonster());
    }

    IEnumerator MakeMonster()
    {
        while (true)
        {
            if (currentLevel == 1)
            {
                SpawnMonsterLevel1();
                yield return new WaitForSeconds(delayTimeLevel1);
            }
            else if (currentLevel >= 2)
            {
                _level2Monster.SetActive(true);
                SpawnMonsterLevel1();
                Debug.Log("1레벨 소환");
                yield return new WaitForSeconds(delayTimeLevel1);
                SpawnMonsterLevel2();
                Debug.Log("2레벨 소환");
                yield return new WaitForSeconds(delayTimeLevel2);
            }
        


            //GameObject monster = Instantiate(_monsterPrefabs, _monsterMakePoint.position, Quaternion.identity);
            //monster.transform.parent = transform;

            //MonsterMove monsterMove = monster.GetComponent<MonsterMove>();
            //if (monsterMove != null)
            //{
            //    monsterMove.targetPlayer.AddComponent<MonsterMove>();
            //}
        }
    }
    void LevelUp()
    {
        Debug.Log("레벨업");
        currentLevel = 2;
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
    }
}