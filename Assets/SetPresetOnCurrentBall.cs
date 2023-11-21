using UnityEngine;

public class UpdateBallParameters : MonoBehaviour
{
    public BallThrowerController ballThrowerController; // Reference to the BallThrowerController script

    public void curveballUpdate()
    {
        ballThrowerController.x0 = 54.53635f;
        ballThrowerController.xv = -117.93326f;
        ballThrowerController.xa = 11.8659f;
        ballThrowerController.y0 = 5.95112f;
        ballThrowerController.yv = -2.82576f;
        ballThrowerController.ya = -15.55566f;
        ballThrowerController.z0 = -1.27162f;
        ballThrowerController.zv = 4.06967f;
        ballThrowerController.za = 2.93165f;

        Debug.Log("Curveball parameters updated.");
    }

    public void fastballUpdate()
    {
        ballThrowerController.x0 = 54.30401f;
        ballThrowerController.xv = -132.6675f;
        ballThrowerController.xa = 16.49743f;
        ballThrowerController.y0 = 6.27917f;
        ballThrowerController.yv = -4.53417f;
        ballThrowerController.ya = -7.10428f;
        ballThrowerController.z0 = -0.88788f;
        ballThrowerController.zv = 3.88111f;
        ballThrowerController.za = -6.30341f;
        Debug.Log("Fastball parameters updated.");
    }

    public void sliderUpdate()
    {
        ballThrowerController.x0 = 54.91364f;
        ballThrowerController.xv = -124.38225f;
        ballThrowerController.xa = 12.80846f;
        ballThrowerController.y0 = 5.7815f;
        ballThrowerController.yv = -5.83793f;
        ballThrowerController.ya = -10.47831f;
        ballThrowerController.z0 = -1.16824f;
        ballThrowerController.zv = 3.63788f;
        ballThrowerController.za = -4.82687f;

        Debug.Log("Slider parameters updated.");
    }

    public void changeUpUpdate()
    {
        ballThrowerController.x0 = 54.81912f;
        ballThrowerController.xv = -122.90993f;
        ballThrowerController.xa = 12.4181f;
        ballThrowerController.y0 = 5.8321f;
        ballThrowerController.yv = -2.67157f;
        ballThrowerController.ya = -9.00343f;
        ballThrowerController.z0 = -1.09937f;
        ballThrowerController.zv = 2.85785f;
        ballThrowerController.za = -3.47889f;

        Debug.Log("Changeup parameters updated.");
    }
}




