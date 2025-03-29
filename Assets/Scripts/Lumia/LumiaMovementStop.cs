using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class LumiaMovementStop : MonoBehaviour
{
    public SplineFollower splineFollow;  // Reference to the SplineFollow script
    public Transform stopPoint;        
    public float stopDistance = 1f;    

    public bool hasStopped = false;

    void Update()
    {
        
        if (Vector3.Distance(splineFollow.transform.position, stopPoint.position) < stopDistance && !hasStopped)
        {
           
            splineFollow.enabled = false;  // Disables the movement of Lumia along the spline

            hasStopped = true;
            Debug.Log("Lumia has stopped moving. You can now interact with her.");
        }
    }
}
