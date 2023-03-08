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
    int SWAP_GATE = 5;
    
    // Maybe make it public sattic?
    int[] inventory = new int[6];

    public string menuScene;

    public string sampleScene;

    public string lvl1, lvl2, lvl3, lvl4, lvl5;

    public int curLevel = 1;

    public GameObject generatorPrefab;

    public GameObject recieverPrefab;

    public GameObject inventoryPrefab;

    public GameObject tilemapPrefab;

    private GameObject tilemap;

    private GameObject inventoryObj;


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


    void OnSceneLoaded (Scene scene, LoadSceneMode mode) {

        inventoryObj = Instantiate(inventoryPrefab);
        inventoryObj.GetComponent<InventoryManager>().setCounts(inventory);
        if (curLevel == 1) {
            Instantiate(generatorPrefab, new Vector3(0,0,0), Quaternion.identity);
        } else if (curLevel == 2) {
            
        }
    }

    // TODO: change menuScene with the approproate lvl variable
    // x: -6 to 5, y: -4 to 4
    public void LevelOne() {
        makeInv(curLevel = 1);
        SceneManager.LoadScene(sampleScene);
        SceneManager.sceneLoaded += OnSceneLoaded;

        //Instantiate(generator, new Vector3(3,0,0), Quaternion.identity);
    }

    public void LevelTwo() {
        makeInv(curLevel = 2);
        SceneManager.LoadScene(sampleScene);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LevelThree() {
        makeInv(curLevel = 3);
        SceneManager.LoadScene(sampleScene);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LevelFour() {
        makeInv(curLevel = 4);
        SceneManager.LoadScene(sampleScene);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LevelFive() {
        makeInv(curLevel = 5);
        SceneManager.LoadScene(sampleScene);
        SceneManager.sceneLoaded += OnSceneLoaded;
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
                inventory[SWAP_GATE] = 6;
                return;
        }

    }

}
