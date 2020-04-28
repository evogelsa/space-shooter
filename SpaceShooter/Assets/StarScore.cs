using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarScore : MonoBehaviour {

    private Image star1;
    private Image star2;
    private Image star3;

    private Color active = new Color(1,1,1,1);

    public GameObject WinScreen;
    private Image WinScreenImage;
    private float alpha = 0f;

    void Start() {
        star1 = GameObject.FindWithTag("Star1").GetComponent<Image>();
        star2 = GameObject.FindWithTag("Star2").GetComponent<Image>();
        star3 = GameObject.FindWithTag("Star3").GetComponent<Image>();
        WinScreenImage = WinScreen.GetComponent<Image>();
    }

    // win condition checking
    void Update() {
        if (star1.color == active && star2.color == active &&
                star3.color == active) {
            Debug.Log("here");
            WinScreen.SetActive(true);
            Time.timeScale -= (1f / 2f) * Time.deltaTime;
            Time.fixedDeltaTime = .02f * Time.timeScale;
            alpha = (1f - Time.timeScale) * (100f/255f);
            WinScreenImage.color = new Color(0, 0, 0, alpha);
            if (Time.timeScale <= .2f) {
                Time.timeScale = 0f;
                Time.fixedDeltaTime = 0f;
            }
        }
    }
}
