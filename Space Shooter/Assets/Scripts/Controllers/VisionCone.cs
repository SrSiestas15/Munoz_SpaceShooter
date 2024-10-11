using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    public float detectionRange;
    public float detectionAngle;
    public Transform targetTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 straightVector = transform.up;

        float straightAngle = Mathf.Atan2(straightVector.y, straightVector.x) * Mathf.Rad2Deg;
        float leftAngle = straightAngle + detectionAngle / 2;
        float rightAngle = straightAngle - detectionAngle / 2;

        float distanceToTarget = Vector3.Distance(transform.position, targetTransform.position);
        bool isObjectCloseEnough = distanceToTarget <= detectionRange;

        float angleToTarget = Vector3.Angle(straightVector, targetTransform.position - transform.position);
        bool isObjectInFront = Mathf.Abs(angleToTarget) <= detectionAngle/2;


        Color lineColour = Color.red;
        if (isObjectCloseEnough && isObjectInFront)
        {
            lineColour = Color.green;
        }

        Vector3 leftVector = DotProduct.AngleToVector(leftAngle) * detectionRange;
        Vector3 rightVector = DotProduct.AngleToVector(rightAngle) * detectionRange;

        Debug.DrawLine(transform.position, transform.position + leftVector, lineColour);
        Debug.DrawLine(transform.position, transform.position + rightVector, lineColour);
    }
}
