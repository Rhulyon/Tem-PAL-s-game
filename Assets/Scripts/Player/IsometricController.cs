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
    private float speed = 2f;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update () {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //Debug.Log(faceDir.ToString());
        if (Input.GetKeyDown(KeyCode.E)){
            DetectInteraction();
        }
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
        if (moveVector.y * moveVector.y >= moveVector.x * moveVector.x)
        {
            if (moveVector.y < 0)
                faceDir = PlayerFaceDirection.Back;
            else
                faceDir = PlayerFaceDirection.Front;
        }
        else
        {
            if (moveVector.x < 0)
                faceDir = PlayerFaceDirection.Left;
            else
                faceDir = PlayerFaceDirection.Right;
        }
        moveVector = CarToIso(moveVector.normalized)*speed;
        
        rb2D.velocity = moveVector;

    }

    public static Vector2 CarToIso(Vector2 cartesianCoord)
    {
        Vector2 ret = new Vector2();
        ret.x = cartesianCoord.x - cartesianCoord.y;
        ret.y = (cartesianCoord.x + cartesianCoord.y )/ 2;
        return ret;
    }
}
