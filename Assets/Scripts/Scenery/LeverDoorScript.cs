﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoorScript : MonoBehaviour
{
    public GameObject DoorGameObject = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	   
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("coll");
        if (col.transform.tag == "Fred" || col.transform.tag == "Zwei" || col.transform.tag == "Dog" || col.transform.tag == "Velma")
        {

            SpriteRenderer rend = gameObject.GetComponent<SpriteRenderer>();
            //ParentGameObject.transform.Find("Door").gameObject.SetActive(false);
            DoorGameObject.transform.Find("OpenedDoor").gameObject.SetActive(true);
            DoorGameObject.transform.Find("ClosedDoor").gameObject.SetActive(false);
            rend.color = Color.green;
            Destroy(col.gameObject);
        }
    }
}
