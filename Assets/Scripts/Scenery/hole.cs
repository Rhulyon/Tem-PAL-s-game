using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class hole : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        IsometricController ic = other.GetComponent<IsometricController>();
        Destroy(ic.gameObject);
    }
}
