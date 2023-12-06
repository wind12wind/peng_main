using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour

{
    
    private void OnTriggerEnter2D(Collider2D SnowBall)
    {
        if (SnowBall.CompareTag("Monster"))
        {
            Destroy(gameObject);
        }

        if (SnowBall.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }



}
