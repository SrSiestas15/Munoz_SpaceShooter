using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Vector3 newAsteroidPosition;
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    


    // Start is called before the first frame update
    void Start()
    {
        newPos();
    }

    // Update is called once per frame
    void Update()
    {
       asteroidMove();
        if ((transform.position - newAsteroidPosition).magnitude <= arrivalDistance)
        {
            newPos();
        }
    }

    void newPos()
    {
        //newAsteroidPosition.x = gameObject.transform.position.x + 1;
        
        newAsteroidPosition.x = transform.position.x + Random.Range(-maxFloatDistance, maxFloatDistance);
        newAsteroidPosition.y = transform.position.y + Random.Range(-maxFloatDistance, maxFloatDistance);
    }
    void asteroidMove()
    {
        transform.position -= (transform.position-newAsteroidPosition) * moveSpeed * Time.deltaTime;
    }
}


