using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class buttonThrow : MonoBehaviour
{
    public Rigidbody rb;
    private float c = 0.304f;
    private float t;
    public Vector3 initBallPosition = new Vector3(-0.76814f, 50f, 6.12393f);
    public float x, xv, xa; // = 54.30401*c, -132.6675*c, 16.49743*c;
    public float y, yv, ya; // = 6.27917*c, -4.53417*c, -7.10428*c;
    public float z, zv, za; // = -0.88788*c, 3.88111*c, -6.30341*c;

    private bool isMoving = true;
    public Button throwButton;


    void Start()
    {
        throwButton.onClick.AddListener(Throw);
    }
    void Throw()
    {
        t = 0f;
        Debug.Log("Throw");
        rb = GetComponent<Rigidbody>();
        // rb.useGravity = true;
        rb.position = initBallPosition;

        // rb.velocity = new Vector3(v0x, v0y, v0z);
        // isMoving = true;
    }
    void Stop()
    {
        Debug.Log("Stop");
        // rb.useGravity = false;
        rb.position = initBallPosition;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        float tsqr = Mathf.Pow(t, 2);
        float tx = x + xv * t + xa * tsqr;
        float ty = y + yv * t + ya * tsqr;
        float tz = z + zv * t + za * tsqr;

        rb.position = new Vector3(tx, ty, tz);
        // Debug.Log(rb.transform.position);
    }
}