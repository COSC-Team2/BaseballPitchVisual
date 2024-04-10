using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRObjectPickup : MonoBehaviour
{
    private Vector3 pickupLocation;

    // Function to save the pickup location
    public void SavePickupLocation()
    {
        pickupLocation = transform.position;
    }

    // Function to return the object to the pickup location
    public void ReturnToPickupLocation()
    {
        transform.position = pickupLocation;
    }

    // This method is called when the object is picked up
    public void OnPickup()
    {
        // You can add any additional logic here when the object is picked up
    }

    // This method is called when the object is dropped
    public void OnDrop()
    {
        // You can add any additional logic here when the object is dropped
    }
}
