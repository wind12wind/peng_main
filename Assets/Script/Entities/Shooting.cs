using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
