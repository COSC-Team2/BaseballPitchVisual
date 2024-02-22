using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallThrowerController : MonoBehaviour
{
    public Rigidbody ballPrefab; // Public variable for the ball prefab
    public Rigidbody currentBall; // Reference to the current ball

    private float convertToMeters = 0.3048f; // Conversion to meters factor
    private float t = 0.0f;
    private float realtime = 0.0f;
    public Slider timeSpeed;


    // Release position at the X, Y, and Z axis. NOTE: These are used for the release point Indicator and not the pitch iteself.
    public float RelHeight;  // Vertical distance of the ball above home plate when the pitcher releases the ball, reported in feet or meters
    public float RelSide;  // Distance from the y-axis from which the pitcher releases the ball, reported in feet or meters.
    public float Extension; // Distance towards home plate from which the pitcher releases the ball relative to the pitching rubber, reported in feet or meters.

    public float PitchTrajectoryXc0; // 0 order coefficient for trajectory polynomial describing x-coordinate of the pitch
    public float PitchTrajectoryXcv;// 1 order coefficient for trajectory polynomial describing x-coordinate of the pitch
    public float PitchTrajectoryXca; // 2 order coefficient for trajectory polynomial describing x-coordinate of the pitch
    public float PitchTrajectoryYc0; // 0 order coefficient for trajectory polynomial describing y-coordinate of the pitch
    public float PitchTrajectoryYcv; // 1 order coefficient for trajectory polynomial describing y-coordinate of the pitch
    public float PitchTrajectoryYca;  // 2 order coefficient for trajectory polynomial describing y-coordinate of the pitch
    public float PitchTrajectoryZc0; // 0 order coefficient for trajectory polynomial describing z-coordinate of the pitch
    public float PitchTrajectoryZcv; // 1 order coefficient for trajectory polynomial describing z-coordinate of the pitch
    public float PitchTrajectoryZca; // 2 order coefficient for trajectory polynomial describing z-coordinate of the pitch


    private float RelHeightFastball = 6.28194f;
    private float RelSideFastball = 0.89337f;
    private float ExtensionFastball = 6.19404f;
    private float x0Fastball = 54.30401f;
    private float xvFastball = -132.6675f;
    private float xaFastball = 16.49743f;
    private float y0Fastball = 6.27917f;
    private float yvFastball = -4.53417f;
    private float yaFastball = -7.10428f;
    private float z0Fastball = -0.88788f;
    private float zvFastball = 3.88111f;
    private float zaFastball = -6.30341f;


    private float RelHeightCurveball = 5.94617f;
    private float RelSideCurveball = 1.26876f;
    private float ExtensionCurveball = 5.96504f;
    private float x0Curveball = 54.53635f;
    private float xvCurveball = -117.93326f;
    private float xaCurveball = 11.8659f;
    private float y0Curveball = 5.95112f;
    private float yvCurveball = -2.82576f;
    private float yaCurveball = -15.55566f;
    private float z0Curveball = -1.27162f;
    private float zvCurveball = 4.06967f;
    private float zaCurveball = 2.93165f;


    private float RelHeightSlider = 5.78121f;
    private float RelSideSlider = 1.17183f;
    private float ExtensionSlider = 5.58746f;
    private float x0Slider = 54.91364f;
    private float xvSlider = -124.38225f;
    private float xaSlider = 12.80846f;
    private float y0Slider = 5.7815f;
    private float yvSlider = -5.83793f;
    private float yaSlider = -10.47831f;
    private float z0Slider = -1.16824f;
    private float zvSlider = 3.63788f;
    private float zaSlider = -4.82687f;


    private float RelHeightChangeUp = 5.83351f;
    private float RelSideChangeUp = 1.10309f;
    private float ExtensionChangeUp = 5.67869f;
    private float x0ChangeUp = 54.81912f;
    private float xvChangeUp = -122.90993f;
    private float xaChangeUp = 12.4181f;
    private float y0ChangeUp = 5.8321f;
    private float yvChangeUp = -2.67157f;
    private float yaChangeUp = -9.00343f;
    private float z0ChangeUp = -1.09937f;
    private float zvChangeUp = 2.85785f;
    private float zaChangeUp = -3.47889f;

    public Button throwButton;

    void Start()
    {
        //throwButton.onClick.AddListener(Throw);
        //currentBall = Instantiate(ballPrefab);
        //test 2/20
    }

    public void Throw()
    {
        Debug.Log("Throw");

        if (currentBall != null)
        {
            Destroy(currentBall.gameObject); // Destroy the existing ball, if any
        }


        t = 0f;
        realtime = 0f;
        currentBall = Instantiate(ballPrefab, new Vector3(PitchTrajectoryXc0, PitchTrajectoryYc0, PitchTrajectoryZc0), Quaternion.identity);

        // Creating starting point indicator after ball is thrown

    }

    void Update()
    {
        if (currentBall != null)
        {
            float tsqr = Mathf.Pow(t, 2);
            float z = convertToMeters * (-PitchTrajectoryXc0 - PitchTrajectoryXcv * t - PitchTrajectoryXca * tsqr);
            float y = convertToMeters * (PitchTrajectoryYc0 + PitchTrajectoryYcv * t + PitchTrajectoryYca * tsqr);
            float x = convertToMeters * (-PitchTrajectoryZc0 - PitchTrajectoryZcv * t - PitchTrajectoryZca * tsqr);

            currentBall.position = new Vector3(x, y, z);

            if (realtime < 0.03f)
            {
                ClearTrail();
            }

            if (currentBall.gameObject.transform.position.z <= -0.125)
            {
                realtime += Time.deltaTime;
                t = realtime * timeSpeed.value;
                //Destroy(currentBall.gameObject);
            }

            // Debug.Log($"X={x} | Y={y} | Z={z} | T={t}");
        }
    }


    void ClearTrail()
    {
        if (currentBall != null && currentBall.GetComponent<TrailRenderer>() != null)
        {
            currentBall.GetComponent<TrailRenderer>().Clear();
            Debug.Log("Trail Cleared");
        }
    }


    public void UpdatePitchType(float relHeight, float relSide, float extension, float pitchTrajectoryXc0, float pitchTrajectoryXcv, float pitchTrajectoryXca, float pitchTrajectoryYc0, float pitchTrajectoryYcv, float pitchTrajectoryYca, float pitchTrajectoryZc0, float pitchTrajectoryZcv, float pitchTrajectoryZca)
    {
        Destroy(currentBall.gameObject);
        RelHeight = relHeight;
        RelSide = relSide;
        Extension = extension;
        PitchTrajectoryXc0 = pitchTrajectoryXc0;
        PitchTrajectoryXcv = pitchTrajectoryXcv;
        PitchTrajectoryXca = pitchTrajectoryXca;
        PitchTrajectoryYc0 = pitchTrajectoryYc0;
        PitchTrajectoryYcv = pitchTrajectoryYcv;
        PitchTrajectoryYca = pitchTrajectoryYca;
        PitchTrajectoryZc0 = pitchTrajectoryZc0;
        PitchTrajectoryZcv = pitchTrajectoryZcv;
        PitchTrajectoryZca = pitchTrajectoryZca;
    }

    public void UpdatePitchTypeToFastball()
    {
        if (currentBall != null)
        {
            Destroy(currentBall.gameObject); // Destroy the existing ball, if any
            ClearTrail();

        }

        currentBall = Instantiate(ballPrefab, new Vector3(PitchTrajectoryXc0, PitchTrajectoryYc0, PitchTrajectoryZc0), Quaternion.identity);

        UpdatePitchType(RelHeightFastball, RelSideFastball, ExtensionFastball, x0Fastball, xvFastball, xaFastball, y0Fastball, yvFastball, yaFastball, z0Fastball, zvFastball, zaFastball);
    }

    public void UpdatePitchTypeToCurveball()
    {
        if (currentBall != null)
        {
            Destroy(currentBall.gameObject); // Destroy the existing ball, if any
            ClearTrail();

        }
        currentBall = Instantiate(ballPrefab, new Vector3(PitchTrajectoryXc0, PitchTrajectoryYc0, PitchTrajectoryZc0), Quaternion.identity);

        UpdatePitchType(RelHeightCurveball, RelSideCurveball, ExtensionCurveball, x0Curveball, xvCurveball, xaCurveball, y0Curveball, yvCurveball, yaCurveball, z0Curveball, zvCurveball, zaCurveball);
    }

    public void UpdatePitchTypeToSlider()
    {
        if (currentBall != null)
        {
            Destroy(currentBall.gameObject); // Destroy the existing ball, if any
            ClearTrail();

        }
        currentBall = Instantiate(ballPrefab, new Vector3(PitchTrajectoryXc0, PitchTrajectoryYc0, PitchTrajectoryZc0), Quaternion.identity);

        UpdatePitchType(RelHeightSlider, RelSideSlider, ExtensionSlider, x0Slider, xvSlider, xaSlider, y0Slider, yvSlider, yaSlider, z0Slider, zvSlider, zaSlider);
    }

    public void UpdatePitchTypeToChangeUp()
    {
        if (currentBall != null)
        {
            Destroy(currentBall.gameObject); // Destroy the existing ball, if any
            ClearTrail();

        }
        currentBall = Instantiate(ballPrefab, new Vector3(PitchTrajectoryXc0, PitchTrajectoryYc0, PitchTrajectoryZc0), Quaternion.identity);

        UpdatePitchType(RelHeightChangeUp, RelSideChangeUp, ExtensionChangeUp, x0ChangeUp, xvChangeUp, xaChangeUp, y0ChangeUp, yvChangeUp, yaChangeUp, z0ChangeUp, zvChangeUp, zaChangeUp);
    }

    public void UpdatePitchTypeToImportedPitch()
    {
        if (currentBall != null)
        {
            Destroy(currentBall.gameObject); // Destroy the existing ball, if any
            ClearTrail();

        }
        currentBall = Instantiate(ballPrefab, new Vector3(PitchTrajectoryXc0, PitchTrajectoryYc0, PitchTrajectoryZc0), Quaternion.identity);

        //TODO
        //PitchType(RelHeightChangeUp, RelSideChangeUp, ExtensionChangeUp, x0ChangeUp, xvChangeUp, xaChangeUp, y0ChangeUp, yvChangeUp, yaChangeUp, z0ChangeUp, zvChangeUp, zaChangeUp);
    }

}