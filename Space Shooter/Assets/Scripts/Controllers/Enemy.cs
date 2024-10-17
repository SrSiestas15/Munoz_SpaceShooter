using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform; //so i can reference the player's position
    Vector3 enemyDirection; //to give the enemy the direction vector towards the player
    public float enemySpeed; //to give the enemy a speed value (can be set later through steam)
    public static Transform publicTransform;

    private void Update()
    {
        publicTransform = transform;
        enemyDirection = transform.position - playerTransform.position; //calculates direction towards the player's current position from the enemy's position
        enemyDirection.Normalize(); //normalize the vector to create a manageable base for the speed
        enemyMovement(); //calls the following function which moves the enemy ship
    }

    void enemyMovement()
    {
        transform.position -= enemyDirection * enemySpeed * Time.deltaTime; 
        //uses a similar movement line as the player, but instead of a simple direction vector, it uses the current vector between player and enemy
    }

}
