using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float firingSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Bullet will destroy itself after 1 second
        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += firingSpeed * Vector3.forward * Time.deltaTime;
        transform.Translate(Vector3.up * firingSpeed * Time.deltaTime);
    }
}
