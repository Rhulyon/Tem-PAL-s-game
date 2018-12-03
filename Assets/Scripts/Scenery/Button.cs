using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject FenceGameObject = null;
    public List<GameObject> tabActors = null;
    public bool pressed = false;
    public Sprite activated;
    public Sprite disactivated;

    // Use this for initialization
    void Start()
    {
        tabActors = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckActors();
    }

    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.transform.tag == "Fred" || col.transform.tag == "Zwei" || col.transform.tag == "Dog" || col.transform.tag == "Velma" || col.transform.tag == "Boulder")
        {
            tabActors.Add(col.gameObject);
            RefreshButton();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

        if (col.transform.tag == "Fred" || col.transform.tag == "Zwei" || col.transform.tag == "Dog" || col.transform.tag == "Velma" || col.transform.tag == "Boulder")
        {
            tabActors.Remove(col.gameObject);
            RefreshButton();
        }
    }

    public void RefreshButton()
    {
        if (tabActors.Count == 0 && pressed)
        {

            FenceGameObject.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().sprite = activated;
            pressed = false;
        }
        else if (tabActors.Count > 0 && !pressed)
        {

            FenceGameObject.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().sprite = disactivated;
            pressed = true;
        }
    }

}
