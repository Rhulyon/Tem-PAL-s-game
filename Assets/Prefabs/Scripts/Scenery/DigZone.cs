using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigZone : MonoBehaviour
{
    public GameObject hiddenObject;

    private bool digged=false;

    public bool Digged { get { return digged; } }

    public void Dig()
    {
        if (digged)
            return;
        //Instantiate(hiddenObject, this.transform.position, Quaternion.identity);
        Debug.Log("You discovered a bone!");
        digged = true;
    }
}
