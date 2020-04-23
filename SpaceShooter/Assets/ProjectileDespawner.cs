using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDespawner : MonoBehaviour {

    private float startTime;
    private float elapsedTime;

    public float lifeSpan = 5f;

    void Start() {
        startTime = Time.time;
    }

    void FixedUpdate() {
        elapsedTime = Time.fixedTime - startTime;
        if (elapsedTime > lifeSpan) {
            Destroy(gameObject);
        }
    }
}
