using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    private float shieldLife = 5f;
    private float shieldStartTime;
    private float shieldElapsedTime;
    private float shieldForce = 5000f;

    public void Activate() {
        shieldStartTime = Time.time;

        if (gameObject.activeSelf)
            shieldStartTime = Time.time;
        else
            gameObject.SetActive(true);
    }

    void FixedUpdate() {
        shieldElapsedTime = Time.fixedTime - shieldStartTime;
        if (shieldElapsedTime > shieldLife) {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Asteroid") {
            Debug.Log("colll");
            Vector2 vel = -col.GetComponent<Rigidbody2D>().velocity;
            col.GetComponent<Rigidbody2D>().AddForce(vel * shieldForce *
                    Time.deltaTime);
        }
    }
}
