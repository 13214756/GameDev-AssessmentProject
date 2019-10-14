using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public AudioClip destroy;
    public GameObject asteroid;

    private float asteroidSpeed = 0.5f;

    private GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        // Getting reference to game controller object and script
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Bullet"))
        {
            // Destroys bullet
            //Destroy(col.gameObject);

            // If large asteroid, spawn smaller ones
            if(transform.localScale == new Vector3(1.5f, 1.5f, 1.5f))
            {
                GameObject smallAsteroid1 = Instantiate(asteroid, new Vector3(transform.position.x - .5f, transform.position.y - .5f, 0), Quaternion.Euler(0, 0, 90));
                smallAsteroid1.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

                GameObject smallAsteroid2 = Instantiate(asteroid, new Vector3(transform.position.x + .5f, transform.position.y + .5f, 0), Quaternion.Euler(0, 0, 180));
                smallAsteroid2.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

                GameObject smallAsteroid3 = Instantiate(asteroid, new Vector3(transform.position.x + .5f, transform.position.y - .5f, 0), Quaternion.Euler(0, 0, 270));
                smallAsteroid3.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

                gameController.SplitAsteroid();
            } else
            {
                // If small asteroid, destroy
                gameController.DecrementAsteroids();
            }

            // Play asteroid destroy sfx
            AudioSource.PlayClipAtPoint(destroy, Camera.main.transform.position);

            // Add to score
            gameController.IncrementScore();

            // Destroy current asteroid
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Pushing asteroid in direction it faces
        transform.Translate(Vector3.up * asteroidSpeed * Time.deltaTime);

    }
}
