using UnityEngine;

/// <summary>
///  Responsible for taking input and applying it to the rigidbody component of the player object.
/// </summary>
[RequireComponent (typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float jumpForce = 5f;
    
    // private and public - public variables can be accessed form other scripts, private variables cannot - within unity, public variables are visible in the inspector, private variables are not - by default, variables are private unless specified otherwise
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Transform groundCheckTransform;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float groundCheckRadius = 0.2f;

    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundLayer);
        float horizontalInput = Input.GetAxis("Horizontal");

        float moveX = horizontalInput * speed;

        rb.linearVelocityX = moveX;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
        
    }
}
