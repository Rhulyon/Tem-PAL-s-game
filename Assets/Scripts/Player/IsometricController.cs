using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerFaceDirection { Front, Back, Left, Right }

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public abstract class IsometricController : MonoBehaviour {
    private float h, v = 0.0f;

    protected BoxCollider2D boxCollider = null;
    protected Rigidbody2D rb2D = null;

    protected Collider2D[] colliders = null;

    protected PlayerFaceDirection faceDir = PlayerFaceDirection.Front;

    [SerializeField]
    private float speed = 0.15f;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update () {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Debug.Log(faceDir.ToString());

        DetectInteraction();
        Move();
	}

    protected virtual void DetectInteraction()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, boxCollider.size.x / 2 + 0.05f);

        foreach(Collider2D collider in colliders)
        {
            switch (collider.tag)
            {
                case "Lever":
                    Lever lever = collider.GetComponent<Lever>();

                    if (lever != null)
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            lever.PullLever();
                        }
                    }

                    break;
            }
        }
    }

    protected virtual void Move()
    {
        Vector2 moveVector = new Vector2(h, v);

        if (moveVector == Vector2.up)
            faceDir = PlayerFaceDirection.Front;
        else if (moveVector == Vector2.down)
            faceDir = PlayerFaceDirection.Back;
        else if (moveVector == Vector2.left)
            faceDir = PlayerFaceDirection.Left;
        else if (moveVector == Vector2.right)
            faceDir = PlayerFaceDirection.Right;

        moveVector = moveVector.normalized * speed;

        rb2D.velocity = moveVector;
    }
}
