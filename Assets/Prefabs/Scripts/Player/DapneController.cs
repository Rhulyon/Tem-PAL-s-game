using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DapneController : IsometricController {


    private Trap trap;
    protected override void DetectInteraction()
    {
        if (trap != null)
        {
            trap.GetComponent<Collider2D>().enabled = false;
            trap = null;
        }
     
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Trap aux;
        if (aux= other.GetComponent<Trap>())
            trap = aux;

    }

    public void OnTriggerExit2D(Collider2D other)
    {

        if ( other.GetComponent<Trap>())
            trap = null;

    }
}
