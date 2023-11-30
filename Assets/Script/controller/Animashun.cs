using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animashun : MonoBehaviour
{
    public Animator penguinA;
    Rigidbody2D rigid; 
    
    public KeyCode key1 = KeyCode.W, S, A, D; 

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        penguinA = GetComponent<Animator>(); //√ ±‚»≠ 
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(key1) || Input.GetKey(S) || Input.GetKey(A) || Input.GetKey(D)) 
        {
            // anim2.SetTrigger("Penguin_Walk"); 
            penguinA.SetBool("Walk", true);
           // penguinA.SetTrigger("walk");
        }
        else
        {
           // penguinA.SetTrigger("stand");
            penguinA.SetBool("Walk", false);
            //anim1.SetTrigger("StandAnimation");
        }
    }
}
