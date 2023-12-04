using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int atk;
    private int maxHp;
    public int currentHp;
    private int maxMp;
    private int currentMp;

    private void Awake()
    {
        atk = 10;
        maxHp = 100;
        currentHp = 100;
        maxMp = 100;
        currentMp = 100;    
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
