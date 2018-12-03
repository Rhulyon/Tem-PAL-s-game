using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script make the boulder static
public class Boulder : MonoBehaviour {

    //The original x,y position
    private Vector2 pos = Vector2.zero;

    private bool isPushed = false;

    public bool IsPushed
    {
        get { return isPushed; }
        set { isPushed = value; }
    }

    public Vector2 Pos
    {
        get { return pos; }
        set { pos = value; }
    }

	void Start () {
        pos = transform.position;
	}

    private void Update()
    {
        if (!isPushed)
        {
            transform.position = pos;
        }
        else
        {
            pos = transform.position;
        }
    }
}
