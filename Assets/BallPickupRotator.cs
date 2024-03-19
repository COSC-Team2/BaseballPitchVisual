using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPickupRotator : MonoBehaviour
{
    public static BallThrowerController ballThrowerController = new BallThrowerController();
    private float spinAxis = ballThrowerController.spinAxis;
    private float spinRate = ballThrowerController.spinAxis;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(spinRate, 0.0f, spinAxis);
        spinRate += 133.33f;
    }
}
