using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : IsometricController {


    private DigZone dz;
    private GameObject nearBone;
    private GameObject myBone;

    public void Update()
    {
        base.Update();
        if (myBone)
        {
            myBone.transform.position = this.transform.position;
        }
    }

    protected override void DetectInteraction()
    {
        base.DetectInteraction();
        if (myBone)
        {
            myBone = null;
        }
        else
        {
            if (nearBone)
            {
                myBone = nearBone;
            }
            if (dz)
            {
                dz.Dig();
            }
        }
        /*colliders = Physics2D.OverlapCircleAll(transform.position, transform.localScale.y / 2 + 0.025f,);

        foreach (Collider2D collider in colliders)
        {
            if ((dz=collider.GetComponent<DigZone>())!=null)
            {
                dz.Dig();
            }
        }*/
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        DigZone aux=other.GetComponent<DigZone>();
        if (aux != null)
            dz = aux;
        if (other.CompareTag("Dog"))
            nearBone = other.gameObject;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        DigZone aux = other.GetComponent<DigZone>();
        if (aux != null)
            dz = null;
        if (other.CompareTag("Dog"))
            nearBone = null;
    }
}
