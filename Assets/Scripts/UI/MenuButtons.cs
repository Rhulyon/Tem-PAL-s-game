using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{

    public GameObject creditsTab;
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.getInstance().SetPauseMenu(this.gameObject);
        gameObject.SetActive(false);

    }



    public void ButtonRestart()
    {
        GameManager.getInstance().Restart();
    }

    public void ButtonCredits()
    {
        creditsTab.SetActive(!creditsTab.activeSelf);
    }

    public void ButtonExit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    void OnEnable()
    {
        Time.timeScale = 0;
        creditsTab.SetActive(false);
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        creditsTab.SetActive(false);
    }
}
