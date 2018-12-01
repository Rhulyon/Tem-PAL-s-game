using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTag : MonoBehaviour
{
    public string LetGo;

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
        if(collision.gameObject.tag == LetGo)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

}