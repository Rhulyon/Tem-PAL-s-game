using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterSwapping : MonoBehaviour {
    /*private vars*/
    private static List<CharacterSwapping> characters = new List<CharacterSwapping>();
    private static CharacterSwapping _activeCharacter;
    private PlayerController playerController;
    private Rigidbody2D rb;

    /*public vars*/
    public bool startCharacter;


    
    public static GameObject activeCharacter
    {
        get
        {
            if (_activeCharacter == null)
                return null;
            return _activeCharacter.gameObject;
        }
    }


    public static event CharacterSwappedFunct characterSwapped;
    public  delegate void CharacterSwappedFunct();

    /*Initialization:
     * if camera is not setted we do that.
     * We create the first character that has startCharacter active as the mainOne
     */
    void Awake () {
        rb = this.GetComponent<Rigidbody2D>();
        playerController=this.GetComponent<PlayerController>();
        playerController.enabled = false;
        rb.velocity = Vector3.zero;
        if (_activeCharacter == null && startCharacter)
        {
            playerController.enabled = true;
            _activeCharacter = this;
            GameManager.getInstance().CameraFollowObject(activeCharacter);
        }
	}
    /*Add to the */
    private void OnEnable()
    {
        characters.Add(this);
    }

    /*If this character is active we remove it and put another one in the spotlight*/
    private void OnDisable()
    {
        if(this.gameObject==_activeCharacter)
        {
            if (characters.Count <= 1)
            {
                _activeCharacter = null;
                if (characterSwapped != null)
                    characterSwapped();

            }
            else
                SwapCharacter();

        }
        characters.Remove(this);
    }

    public static void SwapCharacter()
    {
        int index;
        if (_activeCharacter != null)
        {
            index = characters.IndexOf(_activeCharacter);
            _activeCharacter.playerController.enabled = false;
            _activeCharacter.rb.velocity = Vector3.zero;
            _activeCharacter = characters[(index+1) % characters.Count];
            _activeCharacter.playerController.enabled = true;
        }
        GameManager.getInstance().CameraFollowObject(activeCharacter);
        if (characterSwapped != null)
            characterSwapped();

    }
    

}
