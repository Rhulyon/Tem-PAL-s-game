using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof (KeyDoor))]
[RequireComponent(typeof(Collider2D))]
public class KDEnableCollision : MonoBehaviour {
    private KeyDoor kd;
    private Collider2D col;
    public void Awake()
    {
        kd = this.GetComponent<KeyDoor>();
        col = this.GetComponent<Collider2D>();
    }

    public void OnEnable()
    {
        kd.activateEvent += activateComponent;
    }

    public void OnDisable()
    {
        kd.activateEvent -= activateComponent;
    }

    private void activateComponent(bool active)
    {
        col.enabled = active;
    }


}
