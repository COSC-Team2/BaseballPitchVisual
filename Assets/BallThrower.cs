using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallThrowerController : MonoBehaviour
{
    [Header("Configuration")]
    public GameObject ballPrefab;
    public Button throwButton;

    [Header("Starting Position")]
    public float startingHeight;
    public float startingSide;
    public float startingExtension;

    [Header("Ending Position")]
    public float endingHeight;
    public float endingSide;
    // Ending extension will use the startingExtension for the z-value.

    public float horizontalBreak;
    public float inducedVerticalBreak;
    public float verticalBreak;
    public float startVelocity;
    public float endVelocity;
    public float spinAxis;  // 360-degree value
    public float tilt;  // in degrees
    public float spinRate;  // RPM

    [Header("Visual Trail")]
    public Color trailColor;
    public float trailWidth;
    public float trailDuration;

    public enum PitchType
    {
        Fastball, Curveball, Slider, Changeup
    }
    public PitchType pitchType;

    private GameObject currentBall;

    void Start()
    {
        throwButton.onClick.AddListener(ThrowBall);
    }

    void ThrowBall()
    {
        if (currentBall != null)
            Destroy(currentBall);

        Vector3 start = new Vector3(startingHeight, startingSide, startingExtension);
        currentBall = Instantiate(ballPrefab, start, Quaternion.identity);
        StartCoroutine(MoveBallOnParabola(currentBall));
    }

    IEnumerator MoveBallOnParabola(GameObject ball)
    {
        Vector3 controlPoint = CalculateControlPoint();

        float t = 0;
        Vector3 start = new Vector3(startingHeight, startingSide, startingExtension);
        Vector3 end = new Vector3(endingHeight, endingSide, startingExtension);
        Vector3 previousPosition = start;
        while (t < 1)
        {
            t += Time.deltaTime;
            Vector3 newPos = CalculateBezierPoint(t, start, controlPoint, end);
            Vector3 velocityDirection = (newPos - previousPosition).normalized;
            float currentVelocity = Mathf.Lerp(startVelocity, endVelocity, t);
            ball.transform.position += velocityDirection * currentVelocity * Time.deltaTime;
            previousPosition = ball.transform.position;
            ApplySpin(ball.GetComponent<Rigidbody>(), spinAxis, tilt, spinRate);
            yield return null;
        }

        yield return new WaitForSeconds(2); // Let physics take over for 2 seconds
        Destroy(ball);
    }

    Vector3 CalculateControlPoint()
    {
        Vector3 midPoint = (new Vector3(startingHeight, startingSide, startingExtension) +
                            new Vector3(endingHeight, endingSide, startingExtension)) / 2;
        return new Vector3(midPoint.x + horizontalBreak, midPoint.y + inducedVerticalBreak,
                           midPoint.z + verticalBreak);
    }

    Vector3 CalculateBezierPoint(float t, Vector3 start, Vector3 control, Vector3 end)
    {
        float u = 1 - t;
        Vector3 point = (u * u * start) + (2 * u * t * control) + (t * t * end);
        return point;
    }

    void ApplySpin(Rigidbody rb, float spinAxisDegrees, float tiltDegrees, float spinRateRPM)
    {
        // Convert spin axis and tilt into a 3D rotation axis
        Vector3 spinDirection = new Vector3(Mathf.Sin(spinAxisDegrees * Mathf.Deg2Rad) * Mathf.Sin(tiltDegrees * Mathf.Deg2Rad),
                                            Mathf.Cos(tiltDegrees * Mathf.Deg2Rad),
                                            Mathf.Cos(spinAxisDegrees * Mathf.Deg2Rad) * Mathf.Sin(tiltDegrees * Mathf.Deg2Rad));
        Vector3 spin = spinDirection.normalized * (spinRateRPM * 2f * Mathf.PI / 60f); // Convert RPM to radians per second
        rb.AddTorque(spin);
    }
}






