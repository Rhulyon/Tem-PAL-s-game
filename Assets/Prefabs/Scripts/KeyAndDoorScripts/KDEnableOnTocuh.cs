using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(KeyDoor))]
public class KDEnableOnTocuh : MonoBehaviour {

    private KeyDoor kd;
    public void Awake()
    {
        kd = this.GetComponent<KeyDoor>();

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        kd.Activate= true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        kd.Activate = false;
    }
}
