using UnityEngine;

public class StrikeboxController : MonoBehaviour
{
    public GameObject indicatorPrefab;

    private GameObject[] indicators; // Keep track of all instantiated indicators

    // Used for starting position indicator
    private float RelHeightIndicator = 0f;
    private float RelSideIndicator = 0f;
    private float ExtentionIndicator = -18.47088f;

    private float convertToMeters = 0.3048f; // Conversion to meters factor

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 indicatorPosition = new Vector3(other.transform.position.x, other.transform.position.y, 0f);
            GameObject newIndicator = Instantiate(indicatorPrefab, indicatorPosition, Quaternion.identity);

            // Store the newly instantiated indicator in the array
            AddIndicator(newIndicator);
        }
    }

    public void SpawnStartIndicator(BallThrowerController ballThrower)
    {
        Vector3 indicatorStartPosition = new Vector3((ballThrower.RelSide * convertToMeters), (ballThrower.RelHeight * convertToMeters), (ballThrower.Extension * convertToMeters) - 18.47088f);
        GameObject newStartIndicator = Instantiate(indicatorPrefab, indicatorStartPosition, Quaternion.identity);

        AddIndicator(newStartIndicator);
    }

    private void AddIndicator(GameObject indicator)
    {
        // Add the indicator to the array
        if (indicators == null)
        {
            indicators = new GameObject[] { indicator };
        }
        else
        {
            // Extend the array and add the new indicator
            int length = indicators.Length;
            System.Array.Resize(ref indicators, length + 1);
            indicators[length] = indicator;
        }
    }

    public void DestroyAllIndicators()
    {
        // Destroy all indicators in the array
        if (indicators != null)
        {
            foreach (GameObject indicator in indicators)
            {
                if (indicator != null)
                {
                    Destroy(indicator);
                }
            }

            // Clear the array
            indicators = null;
        }
    }
}
