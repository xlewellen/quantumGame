using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    public string menuScene;
    public string lvl1, lvl2,  lvl3, lvl4, lvl5;

    private int curLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu() {
        SceneManager.LoadScene(menuScene);
    }

    // TODO: change menuScene with the approproate lvl variable

    public void LevelOne() {
        curLevel = 1;
        SceneManager.LoadScene(menuScene);
    }

    public void LevelTwo() {
        curLevel = 2;
        SceneManager.LoadScene(menuScene);
    }

    public void LevelThree() {
        curLevel = 3;
        SceneManager.LoadScene(menuScene);
    }

    public void LevelFour() {
        curLevel = 4;
        SceneManager.LoadScene(menuScene);
    }

    public void LevelFive() {
        curLevel = 5;
        SceneManager.LoadScene(menuScene);
    }
}
