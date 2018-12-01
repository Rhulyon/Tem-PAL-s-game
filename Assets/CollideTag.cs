using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTag : MonoBehaviour
{
    public string LetGo;

    private Collider2D c;

    private void Awake()
    {
        c = this.GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(LetGo))
        {
            c.isTrigger = true;
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(LetGo))
            c.isTrigger = false;


        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        c.isTrigger = false;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }

}