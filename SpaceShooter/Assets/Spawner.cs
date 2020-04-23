using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float ForceMin = 100f;
    public float ForceMax = 800f;

    private float startTimeMin = .25f;
    private float startTimeMax = 2.0f;
    private float timeBetweenSpawn = 1.5f;

    private Vector2 position;

    public Rigidbody2D[] Asteroids;
    private Rigidbody2D Asteroid;

    // Start is called before the first frame update
    void Start() {
        
    }

    void FixedUpdate() {
        if (timeBetweenSpawn <= 0) {
            switch (gameObject.name) {
            case "Spawner Left":
                position = new Vector2(transform.position.x,
                        transform.position.y + Random.Range(-10f,10f));
                break;
            case "Spawner Right":
                position = new Vector2(transform.position.x,
                        transform.position.y + Random.Range(-10f,10f));
                break;
            case "Spawner Top":
                position = new Vector2(transform.position.x +
                        Random.Range(-10f,10f), transform.position.y);
                break;
            case "Spawner Bottom":
                position = new Vector2(transform.position.x +
                        Random.Range(-10f,10f), transform.position.y);
                break;
            }

            GameObject player = GameObject.FindWithTag("Player");
            Vector3 shipPos = player.transform.position;

            Vector2 direction = new Vector2(0, 0);
            direction.x = shipPos.x - position.x;
            direction.y = shipPos.y - position.y;
            direction.Normalize();

            Asteroid = Asteroids[Random.Range(0,2)];

            Rigidbody2D inst = Instantiate(Asteroid, position,
                    Quaternion.identity);
            inst.AddForce(direction * Random.Range(ForceMin,ForceMax));

            timeBetweenSpawn = Random.Range(startTimeMin, startTimeMax);
        } else {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}
