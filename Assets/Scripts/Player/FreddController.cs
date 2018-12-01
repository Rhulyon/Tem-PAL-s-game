using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreddController : IsometricController {

    private bool isHoldingBoulder = false;

    private Boulder currentBoulder = null;

    protected override void Update()
    {
        base.Update();
        if (isHoldingBoulder)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                switch (faceDir)
                {
                    case PlayerFaceDirection.Front:
                        currentBoulder.transform.position = transform.position + Vector3.up * (transform.localScale.y / 2 + currentBoulder.transform.localScale.y / 2);
                        break;
                    case PlayerFaceDirection.Back:
                        currentBoulder.transform.position = transform.position + Vector3.down * (transform.localScale.y / 2 + currentBoulder.transform.localScale.y / 2);
                        break;
                    case PlayerFaceDirection.Left:
                        currentBoulder.transform.position = transform.position + Vector3.left * (transform.localScale.y / 2 + currentBoulder.transform.localScale.y / 2);
                        break;
                    case PlayerFaceDirection.Right:
                        currentBoulder.transform.position = transform.position + Vector3.right * (transform.localScale.y / 2 + currentBoulder.transform.localScale.y / 2);
                        break;
                }

                currentBoulder.Pos = currentBoulder.transform.position;
                
                currentBoulder.IsPushed = false;
                currentBoulder.GetComponent<FixedJoint2D>().enabled = false;
                currentBoulder.GetComponent<FixedJoint2D>().connectedBody = null;

                isHoldingBoulder = false;

                Debug.Log(faceDir + " from fredd");
            }
        }
    }

    protected override void DetectInteraction()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, transform.localScale.y / 2 + 0.025f);

        foreach (Collider2D collider in colliders)
        {
            switch (collider.tag)
            {
                case "Boulder":
                    Boulder boulder = collider.GetComponent<Boulder>();
                    if (boulder != null)
                    {
                        if (Input.GetKeyDown(KeyCode.E) && !isHoldingBoulder)
                        {
                            currentBoulder = boulder;

                            isHoldingBoulder = true;

                            boulder.IsPushed = true;
                            boulder.transform.position = transform.position + Vector3.up * (transform.localScale.y / 2 + boulder.transform.localScale.y / 2);
                            boulder.GetComponent<FixedJoint2D>().enabled = true;
                            boulder.GetComponent<FixedJoint2D>().connectedBody = rb2D;
                        }
                    }
                    break;
                case "Lever":
                    Lever lever = collider.GetComponent<Lever>();

                    if (lever != null)
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            lever.PullLever();
                        }
                    }

                    break;
            }
        }
    }
}
