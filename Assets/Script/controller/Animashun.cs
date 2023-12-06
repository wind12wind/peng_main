using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Animashun : MonoBehaviour
{


    public Animator penguinA;
    public Animator penguinSide;
    public Animator penguinDie; 
    public GameObject player;
    

    public KeyCode key1 = KeyCode.W, S, A, D;
    public KeyCode key2 = KeyCode.Q;
    public KeyCode key3 = KeyCode.E;

    float setTime = 1; //점멸 첫 시간 
    float sideTime = 1; //슬라이딩 진행시간 1초
    float sideCool = 0;

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

        sideCool -= Time.deltaTime; //슬라이딩 쿨타임 
        sideTime -= Time.deltaTime; //슬라이딩 제한시간 지속 마이너스 

        if (Input.GetKeyDown(key2)) //&& sideCool <= 0)
        {
            sideTime = 1; //버튼 누르면 지속시간 1초 플러스 
            if (sideTime > 0)
            {
                penguinSide.SetTrigger("Side");
                CharacterMove.normalSpeed = 20.0f;
            }
        }
        else if (sideTime <= 0) //애니메이션 지속 끝나면? 
        {
            CharacterMove.normalSpeed = 9.0f;
            sideCool = 3;
        }


         setTime -= Time.deltaTime; // 남은 시간을 감소시켜준다.

        if (Input.GetKeyDown(key3))
        {
            if (setTime <= 0)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                player.transform.position = mousePos;
            }
        }
        else if(setTime <= 0 && Input.GetKeyUp(key3))
        {
            setTime = 5; //점멸시간 5초 ㄱㄷ
        }

        Debug.Log($"HP가 {Player.Instance.currentHp} 만큼 남았어!");

        if (Player.Instance.currentHp <= 0) //체력 0보다 같거나 작을 때
        {
            penguinDie.SetBool("YouDie", true); //실행 
        }
        else if(Player.Instance.currentHp > 0)
        {
            penguinDie.SetBool("YouDie", false); //실행 ㄴ
        }
    }
}
