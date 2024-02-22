using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToSelectedLocation : MonoBehaviour
{
    [Header("Teleportation Settings")]
    [Tooltip("Reference to the player or XR rig GameObject that will be teleported.")]
    public Transform playerTransform;

    [Tooltip("Destination transform for the first location.")]
    public Transform location1;

    [Tooltip("Destination transform for the second location.")]
    public Transform location2;

    [Tooltip("Destination transform for the third location.")]
    public Transform location3;

    [Tooltip("Destination transform for the fourth location.")]
    public Transform location4;

    public void TeleportToLocation1()
    {
        TeleportToDestination(location1);
    }

    public void TeleportToLocation2()
    {
        TeleportToDestination(location2);
    }

    public void TeleportToLocation3()
    {
        TeleportToDestination(location3);
    }

    public void TeleportToLocation4()
    {
        TeleportToDestination(location4);
    }

    private void TeleportToDestination(Transform destination)
    {
        if (playerTransform != null && destination != null)
        {
            playerTransform.position = destination.position;
            playerTransform.rotation = destination.rotation;
        }
        else
        {
            Debug.LogWarning("Player Transform or Destination is not set.");
        }
    }
}

    