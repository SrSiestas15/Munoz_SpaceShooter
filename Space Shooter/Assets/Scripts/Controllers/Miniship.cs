using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miniship : MonoBehaviour
{
    Vector3 distanceToParent;
    float tempAngle;
    Vector3 tempPos;

    // Start is called before the first frame update
    void Start()
    {
        distanceToParent = transform.position - Player.shipTransform.position;

        tempAngle = Mathf.Atan2(distanceToParent.y, distanceToParent.x) * Mathf.Rad2Deg;
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(1);
    }

    public void OrbitalMotion(float speed)
    {
        tempPos.x = Mathf.Cos(tempAngle * speed * Mathf.Deg2Rad);
        tempPos.y = Mathf.Sin(tempAngle * speed * Mathf.Deg2Rad);
        transform.position = Player.shipTransform.position + tempPos;
        if (tempAngle == 360 / speed)
        {
            tempAngle = 0;

        }
        else tempAngle++;
    }
}
