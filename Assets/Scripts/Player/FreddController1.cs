using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreddController1 : IsometricController {

    private bool isHoldingBoulder = false;

    private Boulder currentBoulder = null;

    private float fredHeight;
    private float boulderHeight;

    protected override void Awake()
    {
        base.Awake();
        Sprite auxS;
        auxS = this.GetComponent<SpriteRenderer>().sprite;
        fredHeight = auxS.textureRect.height/auxS.pixelsPerUnit;

    }

    protected override void DetectInteraction()
    {
        Sprite auxS;
        if (isHoldingBoulder)
        {
            Vector3 aux=Vector3.zero;
            
            auxS = currentBoulder.GetComponent<SpriteRenderer>().sprite;
            boulderHeight = auxS.textureRect.height / auxS.pixelsPerUnit;
            switch (faceDir)
                {
                    
                    case PlayerFaceDirection.Front:
                        aux = CarToIso(Vector3.up * (transform.localScale.y*fredHeight  + currentBoulder.transform.localScale.y*boulderHeight) / 2);

                        break;
                    case PlayerFaceDirection.Back:
                         aux = CarToIso(Vector3.down * (transform.localScale.y *fredHeight + currentBoulder.transform.localScale.y* boulderHeight) / 2);
                        break;
                    case PlayerFaceDirection.Left:
                         aux = CarToIso(Vector3.left * (transform.localScale.y * fredHeight + currentBoulder.transform.localScale.y * boulderHeight) / 2);
                        break;
                    case PlayerFaceDirection.Right:
                         aux = CarToIso(Vector3.right * (transform.localScale.y * fredHeight + currentBoulder.transform.localScale.y * boulderHeight) / 2);
                        break;
                }
                currentBoulder.transform.position = transform.position + aux;
                currentBoulder.Pos = currentBoulder.transform.position;

                currentBoulder.IsPushed = false;
                currentBoulder.GetComponent<FixedJoint2D>().enabled = false;
                currentBoulder.GetComponent<FixedJoint2D>().connectedBody = null;

                isHoldingBoulder = false;

                //Debug.Log(faceDir + " from fredd");
            return;
        }
        colliders = Physics2D.OverlapCircleAll(transform.position, transform.localScale.y / 2 + 0.025f);

        foreach (Collider2D collider in colliders)
        {
            switch (collider.tag)
            {
                case "Boulder":
                    //Debug.Log("boulder");
                    Boulder boulder = collider.GetComponent<Boulder>();
                    if (boulder != null)
                    {
                        if (!isHoldingBoulder)
                        {
                            currentBoulder = boulder;

                            isHoldingBoulder = true;
                            auxS = currentBoulder.GetComponent<SpriteRenderer>().sprite;
                            boulderHeight = auxS.textureRect.height / auxS.pixelsPerUnit;
                            boulder.IsPushed = true;
                            boulder.transform.position = transform.position + Vector3.up *( transform.localScale.y * fredHeight + currentBoulder.transform.localScale.y * boulderHeight) / 2;
                            boulder.GetComponent<FixedJoint2D>().enabled = true;
                            boulder.GetComponent<FixedJoint2D>().connectedBody = rb2D;
                        }
                    }
                    break;
                case "Lever":
                    Lever lever = collider.GetComponent<Lever>();

                    if (lever != null)
                    {
                            lever.PullLever();
                    }

                    break;
            }
        }
    }
}
