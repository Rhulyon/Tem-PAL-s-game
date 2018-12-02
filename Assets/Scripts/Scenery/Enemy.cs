using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : DangerousTerrain
{
    public List<Transform> pathPoints;
    public float speed;
    public float epsilon = 0.1f;
    

    private Vector3 nextPoint;
    private int pathPoint;
    private bool unCharmed=true;
    // Start is called before the first frame update
    void Start()
    {
        pathPoint = 0;
        if (pathPoints.Count > 0)
            nextPoint = pathPoints[0].position;
        else
        {
            nextPoint = this.transform.position;
            unCharmed = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (unCharmed) { 
            transform.position = Vector3.MoveTowards(transform.position, nextPoint, speed * Time.fixedDeltaTime);
            if (Vector3.SqrMagnitude(transform.position - nextPoint)<epsilon)
            {
                pathPoint = (pathPoint + 1 )% pathPoints.Count;
                if (pathPoints.Count > 0)
                    nextPoint = pathPoints[pathPoint].position;
                else
                {
                    nextPoint = this.transform.position;
                    unCharmed = false;
                }
            }
        }
    }

    public override void  OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.GetComponent<DapneController>())
        {
            unCharmed = false;
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<DapneController>())
        {
            unCharmed = true;
        }

    }
}
