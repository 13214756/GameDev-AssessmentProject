using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    float rotationSpeed = 100.0f;
    float thrustForce = 3f;

    private Vector3 movement;

    public AudioClip crash;
    public AudioClip shoot;

    public GameObject bullet;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        // Referencing game controller object and script
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

    }
    
    void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(inputX, inputY);
        movement = new Vector3(inputX, 0.0f, inputY);

        movement = Vector3.ClampMagnitude(movement, thrustForce);

        // Rotate ship
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        //transform.Translate(movement * thrustForce * Time.deltaTime, Space.World);
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }

        // Thrust ship
        direction.Normalize();
        direction *= (thrustForce * Time.deltaTime);
        transform.position += direction;

        // Firing bullet
        if (Input.GetButtonDown("Fire1"))
        {
            ShootBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Anything except bullet is asteroid
        if (col.gameObject.tag != "Bullet")
        {
            AudioSource.PlayClipAtPoint(crash, Camera.main.transform.position);

            // Move ship to centre of screen
            transform.position = new Vector3(0, 0, 0);

            // Remove all velocity from ship
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

            gameController.DecrementLives();
        }
    }

    void ShootBullet()
    {
        // Spawn bullet
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);

        // Play shooting sound
        AudioSource.PlayClipAtPoint(shoot, Camera.main.transform.position);
    }
}
