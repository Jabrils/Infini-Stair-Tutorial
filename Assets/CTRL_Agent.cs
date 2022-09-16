using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CTRL_Agent : MonoBehaviour
{
    public Transform[] marker;
    NavMeshAgent nMA;
    int ind;
    bool atDestination => nMA.remainingDistance <= 1;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the nav mesh agent
        nMA = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // if at the marker destination
        if (atDestination)
        {
            // increase the marker index
            ind++;

            // define what reaching the last marker means, which is when the index is > than the marker length - 1 (because index starts at 0)
            bool reachedLastMarker = ind > marker.Length - 1;

            // if we've reached the last marker
            if (reachedLastMarker)
            {
                // reset the marker index to reset the loop
                ind = 0;
            }
        }

        // Every frame, let's tell the agent to go to the marker of the current index
        GoTo(marker[ind]);
    }

    void GoTo(Transform dT)
    {
        // set the destination of the nav mesh agent component
        nMA.SetDestination(dT.position);
    }
}
