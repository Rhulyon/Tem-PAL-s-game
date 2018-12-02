using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class EndLevelZone : MonoBehaviour
{
    public static int numberOfCharacters;

    public void Start()
    {
        numberOfCharacters = 0;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<CharacterSwapping>())
        {
            numberOfCharacters++;
            if (CharacterSwapping.GetRemaingCharacters() <= numberOfCharacters)
            {
                GameManager.getInstance().EndLevel();
            }

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        numberOfCharacters--;
    }
}
