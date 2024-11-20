using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1000;
    [HideInInspector]public Vector2 move;
    [HideInInspector]public Rigidbody2D rb;
    [HideInInspector]public SpriteRenderer courtain;

    [HideInInspector]public float lastVel;
    LevelManager lm;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lm = GetComponent<LevelManager>();
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    
    
    private void FixedUpdate()
    {
        ///movement
        rb.AddForce(move * speed * Time.deltaTime);
        lastVel = rb.linearVelocity.x;
    }

    private void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    }
}
