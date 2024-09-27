using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    Vector3 lightTransform;
    public float drawingTime;

    private void Start()
    {
        lightTransform = starTransforms[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i > starTransforms.Count; i++)
        {
            Debug.DrawLine(starTransforms[i].transform.position, lightTransform, Color.white);
            lightTransform += starTransforms[0].transform.position - starTransforms[1].transform.position * drawingTime * Time.deltaTime;
        }


    }

}