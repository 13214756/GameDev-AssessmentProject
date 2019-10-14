using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public AudioClip explode;
    public AudioClip fire;
    public GameObject enemyShip;
    public GameObject bullet;
    
    private float enemySpeed = 0.5f;
    private float shootSpeed = 2.0f;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        // Getting reference to game controller object and script
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

        InvokeRepeating("ShootBullets", 1.0f, shootSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Moving ship in direction it faces
        transform.Translate(Vector3.up * enemySpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
            // Destroys bullet
            Destroy(col.gameObject);

            // Play asteroid destroy sfx
            AudioSource.PlayClipAtPoint(explode, Camera.main.transform.position);

            // Add 3 to score
            gameController.IncrementScore();
            gameController.IncrementScore();
            gameController.IncrementScore();

            // Destroy current asteroid
            Destroy(gameObject);
        }
    }

    void ShootBullets()
    {
        // Spawn bullet
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);

        // Play shooting sound
        AudioSource.PlayClipAtPoint(fire, Camera.main.transform.position);
    }
}