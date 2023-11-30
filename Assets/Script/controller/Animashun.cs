using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animashun : MonoBehaviour
{
    public Animator penguinA;
    public Animator penguinB;
    //Rigidbody2D rigid; 
    
    public KeyCode key1 = KeyCode.W, S, A, D; 

    // Start is called before the first frame update
    void Start()
    {
      //  rigid = GetComponent<Rigidbody2D>();
        penguinA = GetComponent<Animator>(); //초기화 
    }

    // Update is called once per frame
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
    }
}
