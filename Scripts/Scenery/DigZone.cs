using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigZone : MonoBehaviour
{
    public GameObject hiddenObject;

    private bool digged=false;

    public void Dig()
    {
        if (digged)
            return;
        Instantiate(hiddenObject, this.transform.position, Quaternion.identity);
        digged = true;
    }
}
