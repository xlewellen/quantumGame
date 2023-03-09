using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused;

    public GameObject pauseMenuUI;

    public string menuScene;

    private GameObject[] objects;

    void Start() {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    private void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeButton() {
        Resume();
    }


    public void MenuButton() {
        //hardReset();
        Resume();
        SceneManager.LoadScene("Menu");
        /*        hardReset();*/
    }

    public void QuitButton() {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
