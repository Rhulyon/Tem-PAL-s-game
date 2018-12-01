using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script make the boulder static
public class Boulder : MonoBehaviour {
    private Rigidbody2D rb = null;

    //The original x position
    private float xPos = 0.0f;

    private bool isPushed = false;

    public bool IsPushed
    {
        get { return isPushed; }
        set { isPushed = value; }
    }

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        xPos = transform.position.x;
	}

    private void Update()
    {
        if (!isPushed)
        {
            transform.position = new Vector2(xPos, transform.position.y);
        }
        else
        {
            xPos = transform.position.x;
        }
    }
}
