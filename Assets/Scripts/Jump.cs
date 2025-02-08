using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private int jumpPower = 10;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckGroundedStatus();

        if (Input.GetButton("Jump") && isGrounded)
        {
            PerformJump();
        }
    }

    private void CheckGroundedStatus()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.3f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }

    private void PerformJump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpPower);
    }
}
