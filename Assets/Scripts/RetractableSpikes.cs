using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(KeyDoor))]
public class RetractableSpikes : MonoBehaviour
{
    private KeyDoor kd;
    private SpriteRenderer sr;
    private Collider2D coll;

    public Sprite spriteOn;
    public Sprite spriteOff;
    public void Awake()
    {
        kd = this.GetComponent<KeyDoor>();
        sr = this.GetComponent<SpriteRenderer>();
        coll = this.GetComponent<Collider2D>();
    }
    public void OnEnable()
    {
        kd.activateEvent += changeSpikes;
    }

    public void OnDisable()
    {
        kd.activateEvent -= changeSpikes;
    }
    private void changeSpikes(bool status)
    {
        Debug.Log("changed");
        if (status)
        {
            sr.sprite = spriteOn;
            coll.enabled = true;
        }
        else
        {
            sr.sprite = spriteOff;
            coll.enabled = false;
        }
    }
}
