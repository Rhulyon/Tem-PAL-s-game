using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class DogCanPass : MonoBehaviour
{

    private Collider2D c;

    private void Awake()
    {
        c = this.GetComponent<BoxCollider2D>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Dog"))
        {
            Debug.Log(collision.gameObject.tag);
            Physics2D.IgnoreCollision(c, collision.collider);
            
        }

    }


}