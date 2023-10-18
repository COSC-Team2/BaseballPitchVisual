using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWalking : MonoBehaviour
{
    public float movementSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed;
        GetComponent<Rigidbody>().velocity = movement;
    }
}
