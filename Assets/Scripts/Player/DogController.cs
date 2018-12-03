using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : IsometricController {


    private DigZone dz;
    private GameObject nearBone;
    private GameObject myBone;
    private Vector3 offset;
    public void Start()
    {
        Sprite aux;
        offset= Vector3.zero;
        aux = this.GetComponent<SpriteRenderer>().sprite;
        offset.y = aux.textureRect.height / aux.pixelsPerUnit * this.transform.localScale.y/2;
    }
    protected override void Update()
    {
        base.Update();
        if (myBone)
        {
            myBone.transform.position = this.transform.position+offset;
        }
    }

    protected override bool DetectInteraction()
    {
        bool ret = false;
        ret= base.DetectInteraction();
        if (myBone)
        {
            myBone.transform.position -= offset;
            myBone = null;
            ret = true;
            
        }
        else
        {
            if (nearBone)
            {
                myBone = nearBone;
                ret = true;
            }
            if (dz)
            {
                dz.Dig();
                ret = true;
            }
        }
        return ret;
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
