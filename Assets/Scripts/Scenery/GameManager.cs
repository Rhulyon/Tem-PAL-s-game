using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 Singleton related to global game behaviour*/
public class GameManager : MonoBehaviour {
    private static GameManager instance;
    private Transform mainCamera;
    private Transform cameraFollow;
    private int nextLevel;
    private bool endingLevel;

    public int firstLevel=0;

    public float cameraSpeed = 2000.0f;
    public float smoothTime = 0.1f;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            endingLevel = false;
        }
        else
        {
            Destroy(this.gameObject);

        }
    }

    internal void EndLevel()
    {
        
        int sNumber=SceneManager.sceneCount;
        if (endingLevel)
            return;
        endingLevel = true;
        if ((nextLevel=SceneManager.GetActiveScene().buildIndex+1) >= sNumber)
        {
            nextLevel = 0;
            UIMessageSystem.Message("Congratulations you winned the game\nYou Are Awesome\n (press any key to restart)");
        }
        else
        {
            UIMessageSystem.Message("Congratulations you finnished the level\nYou Are Awesome\n (press any key to continue)");
        }
        StartCoroutine(ChangeLevelDelayed());
    }

    private IEnumerator ChangeLevelDelayed()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(nextLevel);
        yield return null;
    }

    public void Start()
    {
        mainCamera = Camera.main.transform;
        SceneManager.sceneLoaded += resetInfo;
    }

    private void resetInfo(Scene arg0, LoadSceneMode arg1)
    {
        mainCamera = Camera.main.transform;
        endingLevel = false;
    }

    public static GameManager getInstance(){
        return instance;    
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
            Restart();
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

    public void Restart()
    {
        if (endingLevel)
            return;
        endingLevel = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    
}
