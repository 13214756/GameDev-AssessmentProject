using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EuclideanTorus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Teleport();
    }

    void Teleport()
    {
        if(transform.position.x > 8)
        {
            transform.position = new Vector3(-8, transform.position.y, 0);
        } else if (transform.position.x < -8)
        {
            transform.position = new Vector3(8, transform.position.y, 0);
        } else if (transform.position.y > 5)
        {
            transform.position = new Vector3(transform.position.x, -5, 0);
        } else if (transform.position.y < -5)
        {
            transform.position = new Vector3(transform.position.x, 5, 0);
        }
    }
}
