using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float firingSpeed = 5f;
    Animation hit;
    Vector3 currentPos;
    //bool isMoving;
    
    // Start is called before the first frame update
    void Start()
    {
        //isMoving = true;
        hit = gameObject.GetComponent<Animation>();
        // Bullet will destroy itself after 1 second
        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += firingSpeed * Vector3.forward * Time.deltaTime;
        //if (isMoving)
        //{
            transform.Translate(Vector3.up * firingSpeed * Time.deltaTime);
        //}
        /*
        else
        {
            transform.Translate(Vector3.zero);
        }*/
    }
    /*
    private void OnCollisionEnter2D()
    {
        isMoving = false;
        hit.Play("BulletBlastAnim");
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }*/
}
