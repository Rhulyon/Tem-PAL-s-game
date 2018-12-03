using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class hole : MonoBehaviour
{
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        CharacterSwapping ic = other.GetComponent<CharacterSwapping>();
        ic.Kill();
    }
}
