using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //TODO: WE NEED ASSETS LMFAO
    // OPTIONS TUTORIAL: https://www.youtube.com/watch?v=eki-6QBtDAg

    // set this to whatever scene the Start button should go to
    public string levelSelectScene;
    public string tutorialScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        SceneManager.LoadScene(levelSelectScene);
    }

    public void OpenOptions() {

    }

    public void CloseOptions() {

    }

    public void Tutorial() {
        SceneManager.LoadScene(tutorialScene);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
