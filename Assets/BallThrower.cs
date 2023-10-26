using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class BallThrowerController : MonoBehaviour
{

    public string fileName = "data.csv"; // Name of the CSV file
    // public GameObject ballPrefab; // The GameObject whose position you want to set
    private List<Vector3> positions = new List<Vector3>();
    private int currentIndex = 0;


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

        string filePath = Path.Combine(Application.dataPath, fileName);
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                if (values.Length >= 3)
                {
                    float x = float.Parse(values[0]);
                    float y = float.Parse(values[1]);
                    float z = float.Parse(values[2]);

                    positions.Add(new Vector3(x, y, z));
                }
            }

            InvokeRepeating("SetPositionFromData", 0.2f, 0.2f);
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }

    void SetPositionFromData()
    {
        if (currentIndex < positions.Count)
        {
            ballPrefab.transform.position = positions[currentIndex];
            currentIndex++;
        }
        else
        {
            Debug.Log("End of data reached.");
            CancelInvoke("SetPositionFromData");
        }
    }
}