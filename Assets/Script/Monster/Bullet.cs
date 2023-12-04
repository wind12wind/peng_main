using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected int atk;
    [SerializeField] protected float speed;

    float DesBullet;

    // Start is called before the first frame update
    void Start()
    {
        DesBullet = GameManager.Instance.CurrentTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentTime > 10f + DesBullet)
        {
            Destroy(gameObject);
        }
    }
}
