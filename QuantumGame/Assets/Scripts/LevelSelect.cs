using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    int TRACKS = 0;
    int H_GATE = 1;
    int Z_GATE = 2;
    int NOT_GATE = 3;
    int M_GATE = 4;
    
    // Maybe make it public sattic?
    int[] inventory = new int[5];

    public string menuScene;
    public string lvl1, lvl2, lvl3, lvl4, lvl5;

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
        makeInv(curLevel = 1);
        SceneManager.LoadScene(menuScene);
    }

    public void LevelTwo() {
        makeInv(curLevel = 2);
        SceneManager.LoadScene(menuScene);
    }

    public void LevelThree() {
        makeInv(curLevel = 3);
        SceneManager.LoadScene(menuScene);
    }

    public void LevelFour() {
        makeInv(curLevel = 4);
        SceneManager.LoadScene(menuScene);
    }

    public void LevelFive() {
        makeInv(curLevel = 5);
        SceneManager.LoadScene(menuScene);
    }

// TODO: Add cases here to fill the inventory for each level
    private void makeInv(int lvl) {
        
        switch (lvl) {

            case 1:
                inventory[TRACKS] = 1;
                inventory[H_GATE] = 2;
                inventory[Z_GATE] = 3;
                inventory[NOT_GATE] = 4;
                inventory[M_GATE] = 5;
                return;
        }
    }

}
