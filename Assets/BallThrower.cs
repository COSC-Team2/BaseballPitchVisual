using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class buttonThrow : MonoBehaviour
{
    public Rigidbody rb;
    private float c = 0.304f;
    private float t = 0.0f;
    public float x0 = 54.30401f;
    public float xv = -132.6675f;
    public float xa = 16.49743f;
    public float y0 = 6.27917f;
    public float yv = -4.53417f;
    public float ya = -7.10428f;
    public float z0 = -0.88788f;
    public float zv = 3.88111f;
    public float za = -6.30341f;

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
        rb.position = new Vector3(x0, y0, z0);
        // isMoving = true;
    }
    void Stop()
    {
        Debug.Log("Stop");
        // rb.useGravity = false;
        // rb.position = initBallPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float tsqr = Mathf.Pow(t, 2);
        float z = c*(-x0 - xv * t - xa * tsqr);
        float y = c*(y0 + yv * t + ya * tsqr);
        float x = c*(-z0 - zv * t - za * tsqr);

        rb.position = new Vector3(x, y, z);
        if (t < 0.05f)
        {
            ClearTrail();
        }
        if (z < 0.0 && y > 0.0)      // if position (z) = home plate, time stops updating
        {
            t += Time.deltaTime;
        }

        Debug.Log($"X={x} | Y={y} | Z={z} | T={t}");
    }
    void ClearTrail()
        {
            rb.GetComponent<TrailRenderer>().Clear();
            Debug.Log("Trail Cleared");
        }
}