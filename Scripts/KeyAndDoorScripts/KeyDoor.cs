using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 DANGER, this code does not has loop detector, making a loop will crash the game.
     */
public class KeyDoor : MonoBehaviour {

    /*
    public delegate void OnActived(bool active);
    public bool startActivated = false;

    public List<KeyDoor> activateOnActivate;
    public List<KeyDoor> activateOnDeactivate;

    public event OnActived activateEvent;

    public bool Activate
    {
        get
        {
            return _activated;
        }
        set
        {
            if (value != _activated)
            {
                _activated = value;
                ActivateSons();
                if (activateEvent != null)
                {
                    activateEvent(value);
                }
            }
        }
    }

    public void Start()
    {
        _activated = startActivated;
        ActivateSons();
    }

    private void ActivateSons()
    {
        foreach(KeyDoor son in activateOnActivate)
        {
            son.Activate = _activated;
        }
        bool noActivate = !_activated;
        foreach(KeyDoor son in activateOnDeactivate)
        {
            son.Activate = noActivate;
        }
    }

    private bool _activated = false;
    */

    //The following part is a rewrite of the code above
    //private Animator _animator;
    private AudioSource _source;

    private bool _opened = false;

    public Collider2D Blocker;
    public AudioClip DoorClip;

    private void Start()
    {
        //_animator = GetComponent<Animator>();
        _source = GetComponent<AudioSource>();
    }

    public void OperateDoor()
    {
        _opened = !_opened;
        Blocker.enabled = (!_opened);
        //_animator.SetBool("Opened", _opened);
        _source.PlayOneShot(DoorClip);
    }
}
