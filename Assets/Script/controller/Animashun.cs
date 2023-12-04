using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Animashun : MonoBehaviour
{
    public Animator penguinA;
    public Animator penguinSide; 
    public GameObject Player;
    //public float sidespeed = 2.0f; 
    //Rigidbody2D rigid; 
    
    public KeyCode key1 = KeyCode.W, S, A, D;
    public KeyCode key2 = KeyCode.Q;
    public KeyCode key3 = KeyCode.E;
    float setTime = 5; //3초

    void Start()
    {
      //  rigid = GetComponent<Rigidbody2D>();
        penguinA = GetComponent<Animator>(); //초기화 
        penguinSide = GetComponent<Animator>(); //깔쌈하게 하나 더 
    }

   

    void Update()
    {

        if(Input.GetKey(key1) || Input.GetKey(S) || Input.GetKey(A) || Input.GetKey(D)) 
        {
            // anim2.SetTrigger("walk"); 
            penguinA.SetBool("Walk", true);
        }
        else
        {
           // penguinA.SetTrigger("stand");
            penguinA.SetBool("Walk", false);
        }

        if(Input.GetMouseButtonDown(0)) //마우스 왼쪽
        {
            penguinA.SetTrigger("Atack");
     
        }

        if (Input.GetKeyDown(key2))
        {
            penguinSide.SetTrigger("Side");

        }

            setTime -= Time.deltaTime;
       // setTime -= Time.deltaTime; // 남은 시간을 감소시켜준다.

        if (Input.GetKeyDown(key3))
        {
            if (setTime <= 0)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Player.transform.position = mousePos;
            }
        }
        else if(setTime <= 0 && Input.GetKeyUp(key3))
        {
            setTime = 5;
        }

    }
}
