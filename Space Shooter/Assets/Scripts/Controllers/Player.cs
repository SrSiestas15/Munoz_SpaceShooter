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

    public float acceleration = 1f;

    public Vector3 velocity;

    private void Start()
    {
        acceleration = targetSpeed / timeToReachTargetSpeed;
        List<string> words = new List<string>();
        words.Add("Dog");
        words.Add("Cat");
        words.Add("Log");
        words.Insert(1, "Rat");
        words.Remove("Dog");
        Debug.Log("Index of cat is: " + words.IndexOf("Cat"));
    }

    void PlayerMovement()
    {

        transform.position += velocity * Time.deltaTime;
        //velocity = Vector3.zero;
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity += Vector3.down * acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += Vector3.right * acceleration *Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += Vector3.up * acceleration *Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity += Vector3.left * acceleration *Time.deltaTime;
        }

        //velocity = velocity.normalized * speed;

    }

    void Update()
    {
        PlayerMovement();
    }

}
