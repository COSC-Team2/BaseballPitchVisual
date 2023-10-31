using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class buttonThrow : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 initBallPosition = new Vector3(0, 2, -18);
    public float v0x = 0;
    public float v0y = 5;
    public float v0z = 20;
    private bool isMoving = true;
    public Button throwButton;

    void Start()
    {
        throwButton.onClick.AddListener(Throw);
    }
    void Throw()
    {
        Debug.Log("Throw");
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.GetComponent<TrailRenderer>().enabled = false;
        rb.position = initBallPosition;
        rb.GetComponent<TrailRenderer>().enabled = true;
        rb.velocity = new Vector3(v0x, v0y, v0z);
        isMoving = true;
    }
    void Stop()
    {
        Debug.Log("Stop");
        rb.useGravity = false;
        rb.position = initBallPosition;
    }



        // Update is called once per frame
        void Update()
        {
        Debug.Log(rb.transform.position);
        }
}