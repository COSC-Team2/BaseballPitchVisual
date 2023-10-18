using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallThrower : MonoBehaviour
{
    public GameObject baseballPrefab;
    public Transform mound;
    public Transform plate;

    // Pitch Parameters
    [Header("Pitch Parameters")]
    public PitchType pitchType = PitchType.Fastball;
    public float velocityMPH = 90f;  // Initial velocity in miles per hour
    public float spinRate = 2000f;   // Spin rate in RPM
    public Vector3 spinAxisDegrees = new Vector3(0f, 0f, 0f);  // Spin axis in degrees (Euler angles)
    public float horizontalBreak = 0f;     // Horizontal break in inches
    public float inducedVerticalBreak = 0f; // Induced vertical break in inches
    public Transform startingPosition; // Transform representing the starting position of the ball

    // Visual Trail Parameters
    [Header("Visual Trail Parameters")]
    public Material trailMaterial;
    public float trailLifetime = 3f;  // Lifetime of the trail in seconds
    public float trailWidth = 0.1f;   // Width of the trail

    private GameObject currentBall;

    public enum PitchType
    {
        Fastball,
        Curveball,
        Slider,
        Changeup
        // Add more pitch types as needed
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get the Button component from your UI button
        Button throwButton = GetComponent<Button>();

        // Add a listener to call the ThrowBall() method when the button is clicked
        throwButton.onClick.AddListener(ThrowBall);
    }

    void ThrowBall()
    {
        // Check if there is already a ball, destroy it if there is
        if (currentBall != null)
        {
            Destroy(currentBall);
        }

        // Instantiate the baseball at the specified starting position
        currentBall = Instantiate(baseballPrefab, startingPosition.position, Quaternion.identity);

        // Apply pitch parameters
        Rigidbody rb = currentBall.GetComponent<Rigidbody>();
        Vector3 direction = (plate.position - mound.position).normalized;
        rb.velocity = CalculatePitchVelocity(direction, velocityMPH);
        ApplySpin(rb, spinAxisDegrees, spinRate);
        ApplyBreaks(rb, horizontalBreak, inducedVerticalBreak);

        // Add a Trail Renderer component to the ball
        TrailRenderer trailRenderer = currentBall.AddComponent<TrailRenderer>();
        trailRenderer.material = trailMaterial;
        trailRenderer.time = trailLifetime;
        trailRenderer.startWidth = trailWidth;
        trailRenderer.endWidth = trailWidth;

        // Destroy the ball and its trail after the specified lifetime
        Destroy(currentBall, trailLifetime);
    }

    Vector3 CalculatePitchVelocity(Vector3 direction, float velocityMPH)
    {
        float velocityMPS = velocityMPH * 0.44704f; // Convert MPH to meters per second
        return direction * velocityMPS;
    }

    void ApplySpin(Rigidbody rb, Vector3 axisDegrees, float spinRate)
    {
        Vector3 axisRadians = new Vector3(
            axisDegrees.x * Mathf.Deg2Rad,
            axisDegrees.y * Mathf.Deg2Rad,
            axisDegrees.z * Mathf.Deg2Rad
        );

        Vector3 spin = axisRadians.normalized * (spinRate * 2f * Mathf.PI / 60f); // Convert RPM to radians per second
        rb.AddTorque(spin, ForceMode.Impulse);
    }

    void ApplyBreaks(Rigidbody rb, float horizontalBreak, float inducedVerticalBreak)
    {
        // Apply horizontal and vertical breaks based on your requirements
        // ... your code here ...
    }
}


