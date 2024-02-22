using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TeleportOnClick : MonoBehaviour
{
    [Header("Teleportation Settings")]
    [Tooltip("Reference to the player or XR rig GameObject that will be teleported.")]
    public Transform playerTransform;

    [Tooltip("Empty GameObject representing the teleportation destination.")]
    public Transform teleportDestination;

    public void TeleportToDestination()
    {
        if (playerTransform != null && teleportDestination != null)
        {
            playerTransform.position = teleportDestination.position;
            playerTransform.rotation = teleportDestination.rotation;
        }
        else
        {
            Debug.LogWarning("Player Transform or Teleport Destination is not set.");
        }
    }
}
