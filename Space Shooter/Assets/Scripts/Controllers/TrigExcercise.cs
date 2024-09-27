using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigExcercise : MonoBehaviour
{
    public List<float> angleList;
    public Vector3 newPos;
    Vector3 anglePosition;
    int angleNum;
    public int radius;
    float timer;
    public float timeChange;

    // Start is called before the first frame update
    void Start()
    {
        angleNum = 0;
        transform.localScale *= radius;
        transform.position = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        anglePosition.x = Mathf.Cos(Mathf.Deg2Rad * angleList[angleNum]);
        anglePosition.y = Mathf.Sin(Mathf.Deg2Rad * angleList[angleNum]);
        Debug.DrawLine(newPos, anglePosition * radius + newPos, Color.red);
        if (timer >= timeChange)
        {
            Debug.Log(anglePosition);
            if (angleNum == angleList.Count-1)
            {
                angleNum = 0;
            }
            else angleNum++;
            timer = 0;
        }
    }
}
