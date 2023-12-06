using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallThrowerController : MonoBehaviour
{
    public Rigidbody ballPrefab; // Public variable for the ball prefab
    public Rigidbody currentBall; // Reference to the current ball

    public TextMeshProUGUI xText;
    public TextMeshProUGUI xvText;
    public TextMeshProUGUI xaText;
    public TextMeshProUGUI yText;
    public TextMeshProUGUI yvText;
    public TextMeshProUGUI yaText;
    public TextMeshProUGUI zText;
    public TextMeshProUGUI zvText;
    public TextMeshProUGUI zaText;     //text references 


    private float c = 0.304f; // Conversion to meters factor
    private float t = 0.0f;

    private string currentPitchType = "Fastball";

    public float x0 = 54.30401f;  // Distance from Plate
    public float xv = -132.6675f; // Speed
    public float xa = 16.49743f;
    public float y0 = 6.27917f;
    public float yv = -4.53417f;
    public float ya = -7.10428f;  // Downward Curve
    public float z0 = -0.88788f;
    public float zv = 3.88111f;
    public float za = -6.30341f;

    private float x0Fastball = 54.30401f;  // Distance from Plate
    private float xvFastball = -132.6675f; // Speed
    private float xaFastball = 16.49743f;
    private float y0Fastball = 6.27917f;
    private float yvFastball = -4.53417f;
    private float yaFastball = -7.10428f;  // Downward Curve
    private float z0Fastball = -0.88788f;
    private float zvFastball = 3.88111f;
    private float zaFastball = -6.30341f;  // Left-Right Curve

    private float x0Curveball = 54.53635f;
    private float xvCurveball = -117.93326f;
    private float xaCurveball = 11.8659f;
    private float y0Curveball = 5.95112f;
    private float yvCurveball = -2.82576f;
    private float yaCurveball = -15.55566f;
    private float z0Curveball = -1.27162f;
    private float zvCurveball = 4.06967f;
    private float zaCurveball = 2.93165f;

    private float x0Slider = 54.91364f;
    private float xvSlider = -124.38225f;
    private float xaSlider = 12.80846f;
    private float y0Slider = 5.7815f;
    private float yvSlider = -5.83793f;
    private float yaSlider = -10.47831f;
    private float z0Slider = -1.16824f;
    private float zvSlider = 3.63788f;
    private float zaSlider = -4.82687f;

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
    }

    public void Throw()
    {
        Debug.Log("Throw");

        if (currentBall != null)
        {
            Destroy(currentBall.gameObject); // Destroy the existing ball, if any
        }

        t = 0f;
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

            UpdateTextValues();

            if (t < 0.05f)
            {
                ClearTrail();
            }

            if (currentBall.gameObject.transform.position.z <= -0.125)
            {
                t += Time.deltaTime;
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
    void UpdateTextValues()
    {
        xText.text = $"x: {x0}";
        xvText.text = $"xv: {xv}";
        xaText.text = $"xa: {xa}";
        yText.text = $"y: {y0}";
        yvText.text = $"yv: {yv}";
        yaText.text = $"ya: {ya}";
        zText.text = $"z: {z0}";
        zvText.text = $"zv: {zv}";
        zaText.text = $"za: {za}";
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

