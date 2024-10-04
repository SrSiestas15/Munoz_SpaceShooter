using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public float AngularSpeed;
    public float TargetAngle;
    float currentAngle;
    Vector3 endPoint;
    public Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //excercise 1
        /*if(currentAngle < TargetAngle)
        {
            transform.Rotate(0, 0, AngularSpeed * Time.deltaTime);
        }
        currentAngle = transform.eulerAngles.z;
        endPoint = transform.position + transform.right;
        Debug.DrawLine(transform.position, endPoint , Color.red);*/

        //lookat excercise
        
        endPoint = transform.position + transform.right;
        Vector3 tempVector = targetTransform.transform.position - transform.position;
        float targetAngle = Mathf.Atan2(tempVector.y, tempVector.x) * Mathf.Rad2Deg;
        Debug.DrawLine(transform.position, endPoint, Color.blue);
        currentAngle = transform.eulerAngles.z;
        if (currentAngle < targetAngle)
        {
            transform.Rotate(0, 0, AngularSpeed * Time.deltaTime);
        }
        
    }
}
