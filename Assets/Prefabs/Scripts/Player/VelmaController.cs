using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelmaController : IsometricController
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("HiddenPath"))
        {
            Debug.Log("Sucess");
            HiddenPath path = collision.collider.GetComponent<HiddenPath>();
            if (path != null)
            {
                GameManager.Instance.SetInetractiveText("open path");
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("HiddenPath"))
        {
            Debug.Log("Sucess");
            HiddenPath path = collision.collider.GetComponent<HiddenPath>();
            if (path != null)
            {
                if (Input.GetKey(KeyCode.E))
                    path.OpenPath();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("HiddenPath"))
        {
            HiddenPath path = collision.collider.GetComponent<HiddenPath>();
            if (path != null)
            {
                GameManager.Instance.ResetInteractiveText();
            }
        }
    }
}
