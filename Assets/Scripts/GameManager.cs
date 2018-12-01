using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 Singleton related to global game behaviour*/
public class GameManager : MonoBehaviour {
    private static GameManager instance;
    private Transform mainCamera;
    private Transform cameraFollow;


    public float cameraSpeed=0.1f;

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
    }
    
    public void Start()
    {
                    mainCamera = Camera.main.transform;
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

    public void LateUpdate()
    {
        Vector3 aux;
        if(cameraFollow!=null){
            aux= Vector3.Lerp(mainCamera.position, cameraFollow.position, cameraSpeed);
            aux.z = mainCamera.position.z;
            mainCamera.position = aux;
        }
    }

    public void FixedUpdate()
    {
        if (Input.GetButtonDown("Swap"))
        {
            CharacterSwapping.SwapCharacter();
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
}
