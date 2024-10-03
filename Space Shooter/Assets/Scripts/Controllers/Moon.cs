using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float rotateSpeed;
    public float rotateRadius;
    public float tempAngle = 0;
    Vector3 tempMoonPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(rotateRadius, rotateSpeed, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        tempMoonPos.x = Mathf.Cos(tempAngle * speed * Mathf.Deg2Rad);
        tempMoonPos.y = Mathf.Sin(tempAngle * speed * Mathf.Deg2Rad);
        transform.position = target.transform.position + tempMoonPos * radius;
        if (tempAngle == 360 / speed)
        {
            tempAngle = 0;
        } else tempAngle++;
    }
}
