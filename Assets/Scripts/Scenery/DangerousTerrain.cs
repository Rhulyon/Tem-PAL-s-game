using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class DangerousTerrain : MonoBehaviour
{

    public virtual void  OnTriggerEnter2D(Collider2D other)
    {
        IsometricController ic= other.GetComponent<IsometricController>();
        if (ic != null&& ic as DapneController ==null)
        {
            other.GetComponent<CharacterSwapping>().Kill() ;
        }
    }
}
