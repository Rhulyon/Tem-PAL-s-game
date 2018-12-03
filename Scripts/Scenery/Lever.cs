using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    private bool isPulled = false;

    public bool IsPulled
    {
        get { return isPulled; }
        set { isPulled = value; }
    }
	
    public void PullLever()
    {
        isPulled = !isPulled;
        Debug.Log("Lever pulled");
    }
}
