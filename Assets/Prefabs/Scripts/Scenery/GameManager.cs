using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 Singleton related to global game behaviour*/
public class GameManager : MonoBehaviour {
    private static GameManager instance;
    private Transform mainCamera;
    private Transform cameraFollow;


    public float cameraSpeed = 2000.0f;
    public float smoothTime = 0.1f;

    public Text InteractiveText = null;

    public static GameManager Instance
    {
        get { return instance; }
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);

        }

        InteractiveText.text = string.Empty;
    }
    
    public void Start()
    {
        mainCamera = Camera.main.transform;
        SceneManager.sceneLoaded += resetInfo;
    }

    private void resetInfo(Scene arg0, LoadSceneMode arg1)
    {
        mainCamera = Camera.main.transform;
    }

    public void OnDestroy()
    {
        if (this == instance)
        {
            instance = null;
        }
    }

    public void Update()
    {
        if (Input.GetButtonDown("Swap"))
        {
            CharacterSwapping.SwapCharacter();
        }
        if(Input.GetButton("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void FixedUpdate()
    {

        Vector3 aux;
        Vector3 aux2;
        if (cameraFollow != null)
        {
            aux = cameraFollow.position;
            aux.z = mainCamera.position.z;
            aux2 = Vector3.zero;
            mainCamera.position = Vector3.SmoothDamp(mainCamera.position, aux, ref aux2, 0.1f, cameraSpeed);

        }
    }

    /*
     * Use to set the camera to follow an object
     */
    public void CameraFollowObject(GameObject followObj){
        if (followObj == null)
            cameraFollow = null;
        else
        cameraFollow=followObj.transform;
    }

    public void SetInetractiveText(string text)
    {
        InteractiveText.text = "Press E to " + text;
    }

    public void ResetInteractiveText()
    {
        InteractiveText.text = string.Empty;
    }
}
