using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    private float shieldLife = 5f;
    private float shieldStartTime;
    private float shieldElapsedTime;

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
}
