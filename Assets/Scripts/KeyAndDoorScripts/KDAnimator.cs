using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(KeyDoor))]
[RequireComponent(typeof(Animator))]
public class KDAnimator : MonoBehaviour {

    private KeyDoor kd;
    private Animator anim;
    public void Awake()
    {
        kd = this.GetComponent<KeyDoor>();
        anim = this.GetComponent<Animator>();
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
        anim.SetBool("Activated",active);
    }


}

