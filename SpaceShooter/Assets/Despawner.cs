using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour {

    public float DespawnDistance = 40f;
    private GameObject player;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        float x = transform.position.x;
        float y = transform.position.y;

        float px = player.transform.position.x;
        float py = player.transform.position.y;

        float dx = (x - px);
        float dy = (y - py);

        float d = dx*dx + dy*dy;

        if (d > (DespawnDistance*DespawnDistance)) {
            Destroy(gameObject);
        }
    }
}
