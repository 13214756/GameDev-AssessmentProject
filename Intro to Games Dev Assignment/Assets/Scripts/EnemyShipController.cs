using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public AudioClip explode;
    public AudioClip fire;
    public GameObject enemyShip;
    public GameObject bullet;
    GameObject playerShip;
    
    private float shootSpeed = 3.0f;
    Vector3 playerPos;
    Vector3 vectorToTarget;
    float angle;
    Quaternion q;
    Quaternion playerAngle;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        // Getting reference to game controller object and script
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

        playerShip = GameObject.FindGameObjectWithTag("Ship");

        InvokeRepeating("ShootBullets", 1.0f, shootSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Moving ship in direction it faces
        //transform.Translate(Vector3.up * enemySpeed * Time.deltaTime);
        //transform.LookAt(playerPos, Vector3.up);

        // Find new pos of player ship
        playerPos = playerShip.transform.position;
        vectorToTarget = playerPos - transform.position;
        angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) + 90;
        q = Quaternion.AngleAxis(angle, Vector3.forward);
        playerAngle = Quaternion.Slerp(transform.rotation, q, Time.deltaTime);
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