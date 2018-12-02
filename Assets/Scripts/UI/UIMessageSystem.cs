using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMessageSystem : MonoBehaviour
{
    private static UIMessageSystem messageSender;
    private int safeTimer;

    public void Awake()
    {
        messageSender = this;
        this.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.anyKeyDown&&safeTimer<=0)
        {
            Debug.Log("keyPressed");
            Time.timeScale=1;
            this.gameObject.SetActive(false);
        }
        safeTimer--;
    }

    public static void Message(string message)
    {
        Time.timeScale = 0;

        messageSender.gameObject.SetActive(true);
        messageSender.safeTimer = 30;
        messageSender.gameObject.GetComponentInChildren<Text>().text = message;
    }
}
