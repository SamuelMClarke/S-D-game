using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce;

    [SerializeField] private LayerMask platformLayerMask;

    private float horizontalInput;
    private Rigidbody2D rb;
    private bool jumpPressed = false;
    private CapsuleCollider2D myCollider;
    private bool sprintPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }

        if (Input.GetKey(KeyCode.LeftControl) && IsGrounded())
        {
            sprintPressed = true;
        }

        if (sprintPressed)
        {
            moveSpeed = 14f;
            sprintPressed = false;
        }
        else
        {
            moveSpeed = 7f;
        }
    }

    private void FixedUpdate() 
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (jumpPressed)
        {
            jumpPressed = false;
            if (IsGrounded())
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }

    }

    private bool IsGrounded()
    {
        float heightCheck = 0.1f;
        RaycastHit2D hit = Physics2D.CapsuleCast(myCollider.bounds.center, myCollider.bounds.size, CapsuleDirection2D.Vertical, 0f, Vector2.down, heightCheck, platformLayerMask);

        return hit.collider != null;
    }
}
