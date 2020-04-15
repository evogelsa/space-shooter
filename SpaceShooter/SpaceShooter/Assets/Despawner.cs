using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        float x = transform.position.x;
        float y = transform.position.y;
        if (x > 20 || x < -20 || y > 20 || y < -20) {
            Destroy(gameObject);
        }
    }
}
