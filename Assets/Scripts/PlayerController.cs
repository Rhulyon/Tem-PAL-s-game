using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float h, v = 0.0f;
    private float jumpCounter = 0.0f;
    private bool isGrounded = false;
    private bool isJumping = false;

    private bool canJump = true;

    private RaycastHit2D[] groundHits = null;
    private Collider2D[] colliders = null;

    private Rigidbody2D rb2D = null;
    private BoxCollider2D boxCollider = null;

    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float jumpForce = 5.0f;
    [SerializeField]
    private float maxJumpTime = 1.5f;
    [SerializeField]
    private LayerMask groundLayers;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        rb2D.velocity = cartesian_to_iso(new Vector2(h * speed, v * speed));
    }

    private void Update()
    {
        CheckGrounded();
        ProcessInteract();
        ProcessJump();
    }

    private Vector2 cartesian_to_iso(Vector2 cartesian)
    {
        Vector2 Isometric = new Vector2();
        Isometric.x = cartesian.x - cartesian.y;
        Isometric.y = (cartesian.x + cartesian.y) / 2;
        return Isometric;
    }

    private void ProcessInteract()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, boxCollider.size.x / 2 + 0.025f);

        foreach (Collider2D collider in colliders)
        {
            switch (collider.tag)
            {
                case "Boulder":
                    Boulder boulder = collider.GetComponent<Boulder>();
                    if (boulder != null && isGrounded)
                    {
                        if (Input.GetKeyDown(KeyCode.S))
                        {
                            canJump = false;

                            boulder.IsPushed = true;
                            boulder.GetComponent<FixedJoint2D>().enabled = true;
                            boulder.GetComponent<FixedJoint2D>().connectedBody = rb2D;

                        }

                        if (Input.GetKeyUp(KeyCode.S))
                        {
                            canJump = true;

                            boulder.IsPushed = false;
                            boulder.GetComponent<FixedJoint2D>().enabled = false;
                            boulder.GetComponent<FixedJoint2D>().connectedBody = null;
                        }
                    }
                    break;
            }
        }
    }

    //i dont think we need to jump on our game
    private void ProcessJump()
    {

        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                isJumping = true;
                jumpCounter = maxJumpTime;
                rb2D.velocity = Vector2.up * jumpForce;
            }

            if (isJumping && Input.GetKey(KeyCode.Space))
            {
                if (jumpCounter > 0)
                {
                    rb2D.velocity = Vector2.up * jumpForce;
                    jumpCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
            }
        }
    }

    private void CheckGrounded()
    {
        groundHits = Physics2D.RaycastAll(transform.position, Vector2.down, boxCollider.size.y / 2 + 0.05f, groundLayers);

        if (groundHits.Length != 0)
        {
            foreach (RaycastHit2D hit in groundHits)
            {
                if (hit.collider.GetInstanceID() == boxCollider.GetInstanceID())
                {
                    if (groundHits.Length == 1)
                    {
                        isGrounded = false;
                        break;
                    }
                    continue;
                }
                if (hit.collider != null)
                {
                    isGrounded = true;
                    break;
                }
            }
        }
        else
        {
            isGrounded = false;
        }
    }
}
