using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    public float ForceMin = 100f;
    public float ForceMax = 800f;

    private float startTimeMin = .5f;
    private float startTimeMax = 2.5f;
    private float timeBetweenSpawn;

    public Rigidbody2D Asteroid;

    private Vector2 position;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (timeBetweenSpawn <= 0) {
            switch (gameObject.name) {
            case "Spawner Left":
                position = new Vector2(transform.position.x,
                        Random.Range(-10,10));
                break;
            case "Spawner Right":
                position = new Vector2(transform.position.x,
                        Random.Range(-10,10));
                break;
            case "Spawner Top":
                position = new Vector2(Random.Range(-10,10), 
                        transform.position.y);
                break;
            case "Spawner Bottom":
                position = new Vector2(Random.Range(-10,10), 
                        transform.position.y);
                break;
            }

            GameObject player = GameObject.FindWithTag("Player");
            Vector3 shipPos = player.transform.position;

            Vector2 direction = new Vector2(0, 0);
            direction.x = shipPos.x - position.x;
            direction.y = shipPos.y - position.y;
            direction.Normalize();

            Rigidbody2D inst = Instantiate(Asteroid, position,
                    Quaternion.identity);
            inst.AddForce(direction * Random.Range(ForceMin,ForceMax));

            timeBetweenSpawn = Random.Range(startTimeMin, startTimeMax);
        } else {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}
