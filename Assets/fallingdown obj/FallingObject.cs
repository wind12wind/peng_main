using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public Rigidbody2D stone;

    void Start()
    {

        stone = GetComponent<Rigidbody2D>();
        Invoke("EnableRigidbody2D", 5f);
    }
    void EnableRigidbody()
    {
        stone.bodyType = RigidbodyType2D.Static;
    }
}
