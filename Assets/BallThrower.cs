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
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.position = initBallPosition;
        rb.velocity = new Vector3(v0x, v0y, v0z);
        isMoving = true;
    }
    void Stop()
    {
        rb.useGravity = false;
        rb.position = initBallPosition;
    }



/*    // Update is called once per frame
    void Update()
    {
        
    }*/
}





/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class BallThrowerController : MonoBehaviour
{
    public string fileName = "data.csv"; // Name of the CSV file
    public GameObject ballPrefab; // Prefab for the ball
    public Button throwButton; // Button for throwing
    private List<Vector3> points = new List<Vector3>();
    private List<GameObject> balls = new List<GameObject>();
    public float speed = 5.0f; // Adjust the speed of the ball

    void Start()
    {
        ReadDataFromCSV();
        throwButton.onClick.AddListener(PlotSpline);
    }

    void ReadDataFromCSV()
    {
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

                    points.Add(new Vector3(x, y, z));
                }
            }
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }

    void PlotSpline()
    {
        GameObject spline = new GameObject("Spline");
        var splineComponent = spline.AddComponent<LineRenderer>();
        splineComponent.material = new Material(Shader.Find("Sprites/Default"));

        Vector3[] pointArray = points.ToArray();

        splineComponent.positionCount = pointArray.Length;
        splineComponent.startWidth = 0.2f;
        splineComponent.endWidth = 0.2f;

        for (int i = 0; i < pointArray.Length; i++)
        {
            splineComponent.SetPosition(i, pointArray[i]);
        }

        StartCoroutine(FollowSpline());
    }

    IEnumerator FollowSpline()
    {
        for (int i = 0; i < points.Count - 3; i++)
        {
            float time = 0;
            while (time < 1)
            {
                time += Time.deltaTime * speed;
                Vector3 ballPosition = GetCatmullRomPosition(time, points[i], points[i + 1], points[i + 2], points[i + 3]);
                GameObject ball = Instantiate(ballPrefab, ballPosition, Quaternion.identity);
                balls.Add(ball);
                yield return null;
            }
        }
    }

    // Catmull-Rom spline interpolation
    private Vector3 GetCatmullRomPosition(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float tt = t * t;
        float ttt = tt * t;

        Vector3 b1 = 0.5f * (2 * p1);
        Vector3 b2 = 0.5f * (-p0 + p2);
        Vector3 b3 = 0.5f * (2 * p0 - 5 * p1 + 4 * p2 - p3);
        Vector3 b4 = 0.5f * (-p0 + 3 * p1 - 3 * p2 + p3);

        return b1 + b2 * t + b3 * tt + b4 * ttt;
    }
}
*/