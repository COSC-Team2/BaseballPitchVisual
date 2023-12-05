using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallThrowerController : MonoBehaviour
{
    public Rigidbody ballPrefab; // Public variable for the ball prefab
    public Rigidbody currentBall; // Reference to the current ball

    private float c = 0.304f; // Conversion to meters factor
    private float t = 0.0f;
    private float realtime = 0.0f;
    public Slider timeSpeed;

    public string currentPitchType = "Fastball";

    public float x0 = 54.30401f;  // Distance from Plate
    public float xv = -132.6675f; // Speed
    public float xa = 16.49743f;
    public float y0 = 6.27917f;
    public float yv = -4.53417f;
    public float ya = -7.10428f;  // Downward Curve
    public float z0 = -0.88788f;
    public float zv = 3.88111f;
    public float za = -6.30341f;

    public float x0Fastball = 54.30401f;  // Distance from Plate
    public float xvFastball = -132.6675f; // Speed
    public float xaFastball = 16.49743f; 
    public float y0Fastball = 6.27917f;
    public float yvFastball = -4.53417f;
    public float yaFastball = -7.10428f;  // Downward Curve
    public float z0Fastball = -0.88788f;
    public float zvFastball = 3.88111f;
    public float zaFastball = -6.30341f;  // Left-Right Curve

    public float x0Curveball = 54.53635f;
    public float xvCurveball = -117.93326f;
    public float xaCurveball = 11.8659f;
    public float y0Curveball = 5.95112f;
    public float yvCurveball = -2.82576f;
    public float yaCurveball = -15.55566f;
    public float z0Curveball = -1.27162f;
    public float zvCurveball = 4.06967f;
    public float zaCurveball = 2.93165f;

    public float x0Slider = 54.91364f;
    public float xvSlider = -124.38225f;
    public float xaSlider = 12.80846f;
    public float y0Slider = 5.7815f;
    public float yvSlider = -5.83793f;
    public float yaSlider = -10.47831f;
    public float z0Slider = -1.16824f;
    public float zvSlider = 3.63788f;
    public float zaSlider = -4.82687f;

    public float x0ChangeUp = 54.81912f;
    public float xvChangeUp = -122.90993f;
    public float xaChangeUp = 12.4181f;
    public float y0ChangeUp = 5.8321f;
    public float yvChangeUp = -2.67157f;
    public float yaChangeUp = -9.00343f;
    public float z0ChangeUp = -1.09937f;
    public float zvChangeUp = 2.85785f;
    public float zaChangeUp = -3.47889f;

public Button throwButton;

    void Start()
    {
        //throwButton.onClick.AddListener(Throw);
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
        currentBall = Instantiate(ballPrefab, new Vector3(x0, y0, z0), Quaternion.identity);


    }

    void Update()
    {
        if (currentBall != null)
        {
            float tsqr = Mathf.Pow(t, 2);
            float z = c * (-x0 - xv * t - xa * tsqr);
            float y = c * (y0 + yv * t + ya * tsqr);
            float x = c * (-z0 - zv * t - za * tsqr);

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

    public void updatePitchTypeToFastball()
    {
        Destroy(currentBall.gameObject);
        x0 = x0Fastball;
        xv = xvFastball;
        xa = xaFastball;
        y0 = y0Fastball;
        yv = yvFastball;
        ya = yaFastball;
        z0 = z0Fastball;
        zv = zvFastball;
        za = zaFastball;
    }

    public void updatePitchTypeToCurveball()
    {
        Destroy(currentBall.gameObject);
        x0 = x0Curveball;
        xv = xvCurveball;
        xa = xaCurveball;
        y0 = y0Curveball;
        yv = yvCurveball;
        ya = yaCurveball;
        z0 = z0Curveball;
        zv = zvCurveball;
        za = zaCurveball;
    }

    public void updatePitchTypeToSlider()
    {
        Destroy(currentBall.gameObject);
        x0 = x0Slider;
        xv = xvSlider;
        xa = xaSlider;
        y0 = y0Slider;
        yv = yvSlider;
        ya = yaSlider;
        z0 = z0Slider;
        zv = zvSlider;
        za = zaSlider;
    }

    public void updatePitchTypeToChangeUp()
    {
        Destroy(currentBall.gameObject);
        x0 = x0ChangeUp;
        xv = xvChangeUp;
        xa = xaChangeUp;
        y0 = y0ChangeUp;
        yv = yvChangeUp;
        ya = yaChangeUp;
        z0 = z0ChangeUp;
        zv = zvChangeUp;
        za = zaChangeUp;
    }
}

