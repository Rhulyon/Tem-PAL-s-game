using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IsometricController))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterSwapping : MonoBehaviour {
    /*private vars*/
    private const float BUNCHOFDRAG = 10000;
    private static List<CharacterSwapping> characters = new List<CharacterSwapping>();
    private static CharacterSwapping _activeCharacter;
    private IsometricController playerController;
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
        playerController=this.GetComponent<IsometricController>();
        playerController.enabled = false;
        rb.velocity = Vector3.zero;
        rb.drag = BUNCHOFDRAG;
        if (_activeCharacter == null && startCharacter)
        {
            rb.drag = 0;
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

        if(this==_activeCharacter)
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
            _activeCharacter.rb.drag = BUNCHOFDRAG;
            _activeCharacter = characters[(index+1) % characters.Count];
            _activeCharacter.playerController.enabled = true;
            _activeCharacter.rb.drag = 0;
        }
        GameManager.getInstance().CameraFollowObject(activeCharacter);
        if (characterSwapped != null)
            characterSwapped();

    }

    public static int GetRemaingCharacters()
    {
        return characters.Count;
    }


    public void OnDestroy()
    {

            if (EndLevelZone.numberOfCharacters >= characters.Count)
            {
                GameManager.getInstance().EndLevel();
            }
            if (characters.Count == 0)
            {
            
                GameManager.getInstance().Restart();
            }
        
    }

}
