using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float floatHeight = 0.2f; // The height the object will float above its initial position
    public float floatSpeed = 1f; // The speed at which the object will float

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // Store the initial position of the object
    }

    void Update()
    {
        // Calculate the new Y position using a sin wave to create the floating effect
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Update the object's position with the new Y coordinate
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
