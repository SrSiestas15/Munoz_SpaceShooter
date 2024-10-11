using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotProduct : MonoBehaviour
{
    public float redAngle;
    public float blueAngle;
    float dotProductResult;
    Vector3 redVector;
    Vector3 blueVector;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        redVector = DotProduct.AngleToVector(redAngle);
        blueVector = DotProduct.AngleToVector(blueAngle);

        Debug.DrawLine(Vector3.zero, redVector, Color.red);
        Debug.DrawLine(Vector3.zero, blueVector, Color.blue);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log(redVector.y);
            //Debug.Log(blueVector.y);
            dotProduct(redVector, blueVector);
            Debug.Log(dotProductResult);
            Debug.Log(Vector3.Dot(redVector, blueVector));
        }
    }

    void dotProduct(Vector3 vector1, Vector3 vector2)
    {
        dotProductResult = vector1.x * vector2.x + vector1.y * vector2.y;
    }

    public static Vector3 AngleToVector(float angle)
    {
        float x = Mathf.Cos(Mathf.Deg2Rad * angle);
        float y = Mathf.Sin(Mathf.Deg2Rad * angle);

        Vector3 vector = new Vector3(x, y);

        return vector;
    }
}
