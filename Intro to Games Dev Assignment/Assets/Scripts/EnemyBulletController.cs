using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    float firingSpeed = 1f;
    //Vector3 playerPos;

    private GameObject playerShip;

    // Start is called before the first frame update
    void Start()
    {
        // Getting reference to player ship
        playerShip = GameObject.FindWithTag("Ship");
        //playerPos = playerShip.transform.position;

        // Bullet will destroy itself after 1 second
        Destroy(gameObject, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(playerShip.transform);
        transform.Translate(Vector3.up * firingSpeed * Time.deltaTime);
    }
}
