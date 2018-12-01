using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricController : MonoBehaviour {
    private float h, v = 0.0f;

    private BoxCollider2D boxCollider;
    private Collider2D[] colliders = null;

    [SerializeField]
    private float speed = 0.15f;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update () {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        DetectInteraction();
        Move();
	}

    private void DetectInteraction()
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

    private void Move()
    {
        Vector2 moveVector = new Vector2(h, v);
        moveVector = moveVector.normalized * speed;

        transform.Translate(moveVector);
    }
}
