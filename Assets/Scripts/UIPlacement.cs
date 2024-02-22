using UnityEngine;

public class UIPlacement : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's Transform
    public Transform uiContainer; // Reference to the UI container

    private Vector3 initialOffset; // Initial offset between player and UI

    void Start()
    {
        // Calculate the initial offset between player and UI
        initialOffset = uiContainer.position - playerTransform.position;
    }

    void Update()
    {
        // Update positions and rotations for all children of the UI container
        foreach (Transform child in uiContainer)
        {
            child.position = playerTransform.position + initialOffset;
            child.rotation = Quaternion.LookRotation(playerTransform.position - child.position);
        }
    }

    public void TeleportUIWithPlayer()
    {
        // Teleport all children of the UI container to match the player's position and rotation
        foreach (Transform child in uiContainer)
        {
            child.position = playerTransform.position + initialOffset;
            child.rotation = Quaternion.LookRotation(playerTransform.position - child.position);
        }
    }
}
