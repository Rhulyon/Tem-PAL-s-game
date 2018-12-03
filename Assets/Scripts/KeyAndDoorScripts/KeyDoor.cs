using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 DANGER, this code does not has loop detector, making a loop will crash the game.
     */
public class KeyDoor : MonoBehaviour {

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
        if(activateEvent!=null)
            activateEvent(_activated);

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


}
