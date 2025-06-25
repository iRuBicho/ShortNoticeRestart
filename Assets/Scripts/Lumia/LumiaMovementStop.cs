using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class LumiaMovementStop : MonoBehaviour
{
    public SplineFollower splineFollow;
    public Transform stopPoint;
    public float stopDistance = 1f;

    public bool hasStopped = false;

    public CompanionFollowNavMesh sideFollower;



    void Update()
    {
        if (Vector3.Distance(splineFollow.transform.position, stopPoint.position) < stopDistance && !hasStopped)
        {
            splineFollow.enabled = false;
            hasStopped = true;
            if (sideFollower != null)
            {
                sideFollower.enabled = true;
            }
            Debug.Log("Lumia has stopped moving. Side follow activated.");
        }
    }
}
