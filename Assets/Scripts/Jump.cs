using System.Collections;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private int jumpPower = 10;
    [SerializeField] private float fallMultiplier = 2.5f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Vector2 _gravityVector;
    private bool _isGrounded;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _gravityVector = new Vector2(0, -Physics2D.gravity.y);
    }

    private void Update()
    {
        CheckGroundedStatus();

        if (Input.GetButton("Jump") && _isGrounded)
        {
            PerformJump();
        }

        ApplyFallMultiplier();
    }

    private void CheckGroundedStatus()
    {
        _isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.3f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

    private void PerformJump()
    {
        _rb.linearVelocity = new Vector2(_rb.linearVelocityX, jumpPower);
    }

    private void ApplyFallMultiplier()
    {
        if (_rb.linearVelocityY < 0)
        {
            _rb.linearVelocity -= _gravityVector * fallMultiplier * Time.deltaTime;
        }
    }
}
