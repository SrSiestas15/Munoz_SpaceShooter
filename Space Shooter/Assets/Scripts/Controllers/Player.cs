using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public float targetSpeed = 3f;
    public float timeToReachTargetSpeed = 2f;
    public float maxSpeed = 3f;
    float testTimer = 0;

    public float acceleration = 1f;

    public float radius;
    public float numOfPoints;
    float indAngle;
    Vector3 tempRadarPoint1;
    Vector3 tempRadarPoint2;
    Color radarColor;

    public Vector3 velocity;

    private void Start()
    {
        acceleration = targetSpeed / timeToReachTargetSpeed;

        indAngle = 360 / numOfPoints;
        Debug.Log(indAngle);
    }

    void PlayerMovement()
    {
        transform.position += velocity * Time.deltaTime;


        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity += Vector3.down * acceleration * Time.deltaTime;
        }
        else if (velocity.y < 0)
        {
            velocity += Vector3.up * acceleration * Time.deltaTime;
        }
      
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += Vector3.right * acceleration *Time.deltaTime;
        }
        else if (velocity.x > 0)
        {
            velocity += Vector3.left * acceleration * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += Vector3.up * acceleration *Time.deltaTime;
        }
        else if (velocity.y > 0)
        {
            velocity += Vector3.down * acceleration * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity += Vector3.left * acceleration *Time.deltaTime;
        }
        else if (velocity.x < 0)
        {
            velocity += Vector3.right * acceleration * Time.deltaTime;
        }

        if (velocity.magnitude >= maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }

    }

    void Update()
    {
        testTimer += Time.deltaTime;
        PlayerMovement();
        EnemyRadar(radius, (int) numOfPoints);
    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        Vector3 playerToEnemy = transform.position - enemyTransform.position;
        if (playerToEnemy.magnitude < radius) 
        {
            radarColor = Color.red;
        } else radarColor = Color.green;

        for (int i = 0; i < circlePoints; i++)
        {
            tempRadarPoint1.x = Mathf.Cos(indAngle * i * Mathf.Deg2Rad);
            tempRadarPoint1.y = Mathf.Sin(indAngle * i * Mathf.Deg2Rad);
            tempRadarPoint2.x = Mathf.Cos(indAngle * (i+1) * Mathf.Deg2Rad);
            tempRadarPoint2.y = Mathf.Sin(indAngle * (i+1) * Mathf.Deg2Rad);
            Debug.DrawLine(transform.position + tempRadarPoint1 * radius, transform.position +tempRadarPoint2 *radius, radarColor);
            //Debug.Log(indAngle * circlePoints);
        }
    }

}
