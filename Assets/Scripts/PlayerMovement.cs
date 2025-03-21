using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private Collider2D coll;

    [SerializeField]
    private LayerMask groundLayer;
    private Rigidbody2D body;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Start() { }

    private void Update() { }

    private void FixedUpdate()
    {
        Move();
        AutoJump();
    }

    private void Move()
    {
        body.linearVelocity = new Vector2(
            Input.GetAxis("Horizontal") * speed,
            body.linearVelocity.y
        );
    }

    private void AutoJump()
    {
        if (IsGrounded())
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector2.down * 0.80f, Color.red);
        return Physics2D.Raycast(transform.position, Vector2.down, 0.80f, groundLayer);
    }
}
