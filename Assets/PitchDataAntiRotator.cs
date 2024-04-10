using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PitchDataAntiRotator : MonoBehaviour
{
    private Vector3 originalParent;
    private Vector3 offset = new Vector3(0f, 0.15f, -0.25f);

    // Start is called before the first frame update
    void Start()
    {
        originalParent = transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = originalParent + offset;
        gameObject.transform.rotation = Quaternion.Euler(14f, 180f, 0f);
    }
}
