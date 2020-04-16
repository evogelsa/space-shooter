using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    private int onLaunch;

    void Start() {
        if (PlayerPrefs.HasKey("onLaunch")) {
            onLaunch = PlayerPrefs.GetInt("onLaunch");
            if (onLaunch == 1) {
                Pause();
                PlayerPrefs.SetInt("onLaunch", 0);
            }
        } else {
            PlayerPrefs.SetInt("onLaunch", 0);
            Pause();
        }
    }

    void OnApplicationQuit() {
        PlayerPrefs.DeleteKey("onLaunch");
    }
    
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause() {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Controls() {
        //TODO 
    }

    public void Quit() {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
