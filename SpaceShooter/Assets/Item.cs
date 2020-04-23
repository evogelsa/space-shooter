using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public GameObject shield;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            switch (gameObject.tag) {
            case "ShieldItem":
                shield.GetComponent<Shield>().Activate();
                Destroy(gameObject);
                break;
            }
        }
    }
}
