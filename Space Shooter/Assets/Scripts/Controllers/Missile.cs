using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    //public Transform enemyTransform;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 tempVector = transform.position - Enemy.publicTransform.position;
        float targetAngle = Mathf.Atan2(tempVector.y, tempVector.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, targetAngle + 90);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * 3 * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        GameObject.Destroy(gameObject);
    }

}
