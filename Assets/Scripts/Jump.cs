using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int jumpPower;
    [SerializeField] float fallMultiplier;

    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    Vector2 vecGravity;

    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //groundcheck
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.3f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2 (rb.linearVelocity.x, jumpPower);
        }
        //fall multiplier, CURRENTLY NOT USED BUT MAYBE LATER IMPLEMENTATION
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity -= vecGravity * fallMultiplier * Time.deltaTime; 
        }
    }
}
