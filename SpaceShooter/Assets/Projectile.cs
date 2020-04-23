using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Asteroid") {
            Destroy(gameObject);
            Destroy(col.gameObject);
        } else if (col.tag != "Player" && col.tag != "ShieldEffect") {
            Destroy(gameObject);
        }
    }
}
