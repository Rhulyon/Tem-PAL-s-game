using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenPath : MonoBehaviour
{
    private SpriteRenderer _renderer = null;

    [SerializeField][Tooltip("The collider that blocks the path before the path is opened")]
    private Collider2D pathBlocker = null;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();

        pathBlocker.enabled = true;

        if (_renderer != null)
            _renderer.enabled = false;
    }

    public void OpenPath()
    {
        _renderer.enabled = true;
        pathBlocker.enabled = false;
    }
}
