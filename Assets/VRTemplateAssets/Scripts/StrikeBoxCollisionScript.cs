using UnityEngine;

public class ObjectA : MonoBehaviour
{
    public GameObject objectB; // Reference to object B (assign this in the Inspector)
    public Material redMaterial; // Material for the red circle

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == objectB)
        {
            Debug.Log("collide");
            Vector3 contactPoint = collision.contacts[0].point;

            // Create a red circle at the collision point on object A
            DrawRedCircle(contactPoint);
        }
    }

    public void ResetRedCircles()
    {
        // Find and remove all red circles drawn
        LineRenderer[] redCircles = GetComponentsInChildren<LineRenderer>();
        foreach (LineRenderer redCircle in redCircles)
        {
            Destroy(redCircle.gameObject);
        }
    }

    void DrawRedCircle(Vector3 center)
    {
        GameObject redCircleObject = new GameObject("RedCircle");
        redCircleObject.transform.parent = transform;

        LineRenderer lineRenderer = redCircleObject.AddComponent<LineRenderer>();
        lineRenderer.material = redMaterial;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 50;

        float angle = 0f;
        float angleIncrement = (2 * Mathf.PI) / lineRenderer.positionCount;

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            float x = center.x + Mathf.Cos(angle) * 0.5f;
            float z = center.z + Mathf.Sin(angle) * 0.5f;
            lineRenderer.SetPosition(i, new Vector3(x, center.y, z));

            angle += angleIncrement;
        }
    }
}
