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

    //radar
    public float radarRadius;
    public float numOfPoints;
    float radarIndAngle;
    Vector3 tempRadarPoint1;
    Vector3 tempRadarPoint2;
    Color radarColor;

    //powerups
    public GameObject powerupPrefab;
    public float powerupRadius;
    public float numOfPowerups;
    float powerupIndAngle;

    //bullet
    public GameObject bulletPrefab;

    //partner ship
    public GameObject partnershipPrefab;
    float partnershipIndAngle;
    public int numOfPartnerships;
    public float partnershipRadius;
    public static Transform shipTransform;

    //missiles
    public GameObject missilePrefab;



    public Vector3 velocity;

    private void Start()
    {
        shipTransform = transform;
        acceleration = targetSpeed / timeToReachTargetSpeed;

        radarIndAngle = 360 / numOfPoints;
        //Debug.Log(radarIndAngle);

        powerupIndAngle = 360 / numOfPowerups;
        partnershipIndAngle = 360 / numOfPartnerships;
        SpawnPartnerShip(numOfPartnerships);
        Debug.Log(Mathf.Atan2(0, 1)*Mathf.Rad2Deg);
        Debug.Log(Mathf.Atan2(0, -1) * Mathf.Rad2Deg);
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
        shipTransform = transform;
        testTimer += Time.deltaTime;
        PlayerMovement();
        //EnemyRadar(radarRadius, (int) numOfPoints);
        
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            //SpawnPowerups(powerupRadius, (int)numOfPowerups);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab,transform.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            shootMissile(missilePrefab);
        }
    }

    public void EnemyRadar(float radarRadius, int circlePoints)
    {
        Vector3 playerToEnemy = transform.position - enemyTransform.position;
        if (playerToEnemy.magnitude < radarRadius) 
        {
            radarColor = Color.red;
        } else radarColor = Color.green;

        for (int i = 0; i < circlePoints; i++)
        {
            tempRadarPoint1.x = Mathf.Cos(radarIndAngle * i * Mathf.Deg2Rad);
            tempRadarPoint1.y = Mathf.Sin(radarIndAngle * i * Mathf.Deg2Rad);
            tempRadarPoint2.x = Mathf.Cos(radarIndAngle * (i+1) * Mathf.Deg2Rad);
            tempRadarPoint2.y = Mathf.Sin(radarIndAngle * (i+1) * Mathf.Deg2Rad);
            Debug.DrawLine(transform.position + tempRadarPoint1 * radarRadius, transform.position +tempRadarPoint2 *radarRadius, radarColor);
            //Debug.Log(radarIndAngle * circlePoints);
        }
    }

    /*public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        for (int i = 0; i < numOfPowerups; i++)
        {

            tempRadarPoint1.x = Mathf.Cos(powerupIndAngle * i * Mathf.Deg2Rad);
            tempRadarPoint1.y = Mathf.Sin(powerupIndAngle * i * Mathf.Deg2Rad);
            Instantiate(powerupPrefab, transform.position + tempRadarPoint1 * powerupRadius, Quaternion.identity);
        }
    }*/

    void SpawnPartnerShip(int numOfPartnerships)
    {
        for (int i = 0; i < numOfPartnerships; i++)
        {
            tempRadarPoint1.x = Mathf.Cos(partnershipIndAngle * i * Mathf.Deg2Rad);
            tempRadarPoint1.y = Mathf.Sin(partnershipIndAngle * i * Mathf.Deg2Rad);
            Instantiate(partnershipPrefab, transform.position + tempRadarPoint1 * powerupRadius, Quaternion.identity);
        }
    }

    void shootMissile(GameObject missile)
    {
        Instantiate(missile, transform.position, Quaternion.identity);
    }
}
