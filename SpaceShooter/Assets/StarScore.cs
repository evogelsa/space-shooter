using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarScore : MonoBehaviour {

    private Image star1;
    private Image star2;
    private Image star3;

    private Color active = new Color(255,255,255,255);

    void Start() {
        star1 = GameObject.FindWithTag("Star1").GetComponent<Image>();
        star2 = GameObject.FindWithTag("Star2").GetComponent<Image>();
        star3 = GameObject.FindWithTag("Star3").GetComponent<Image>();

    }

    void Update() {
        if (star1.color == active && star2.color == active &&
                star3.color == active) {
            Debug.Log("WIN");
        }
    }
}
