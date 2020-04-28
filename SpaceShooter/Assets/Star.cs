using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour {

    private GameObject star1;
    private GameObject star2;
    private GameObject star3;

    void Start() {
        star1 = GameObject.FindWithTag("Star1");
        star2 = GameObject.FindWithTag("Star2");
        star3 = GameObject.FindWithTag("Star3");
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            Color c = new Color(1,1,1,1);
            switch (gameObject.name) {
            case "StarItem1":
                star1.GetComponent<Image>().color = c;
                break;
            case "StarItem2":
                star2.GetComponent<Image>().color = c;
                break;
            case "StarItem3":
                star3.GetComponent<Image>().color = c;
                break;
            }
            Destroy(gameObject);
        }
    }

}
