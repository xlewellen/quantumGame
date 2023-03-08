using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class LevelSelect : MonoBehaviour
{

    int TRACKS = 0;
    int H_GATE = 1;
    int Z_GATE = 2;
    int NOT_GATE = 3;
    int M_GATE = 4;
    int SWAP_GATE = 5;

    // Maybe make it public sattic?

    private int[] inventory = new int[6];

    public string menuScene;

    public string sampleScene;

    public string lvl1, lvl2, lvl3, lvl4, lvl5;

    public int curLevel = 1;

    public GameObject generatorPrefab;

    public GameObject recieverPrefab;

    public GameObject inventoryPrefab;

    public GameObject tilemapPrefab;

    private GameObject tilemapObj;

    private GameObject inventoryObj;

    private ArrayList recievers = new ArrayList();

    private float half = 1 / Mathf.Sqrt(2);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void instantiateGenerator(Vector3 location, float alpha, float beta) {
        GameObject gen = Instantiate(generatorPrefab, location, Quaternion.identity);
        gen.GetComponent<GeneratorManager>().targetalpha = alpha;
        gen.GetComponent<GeneratorManager>().targetbeta = beta;
    }

    private void instantiateReceiver(Vector3 location, float alpha, float beta, int target)
    {
        GameObject rec = Instantiate(recieverPrefab, location, Quaternion.identity);
        rec.GetComponent<ReceiverManager>().targetalpha = alpha;
        rec.GetComponent<ReceiverManager>().targetbeta = beta;
        rec.GetComponent<ReceiverManager>().target = target;
    }

    public void BackToMenu() {
        SceneManager.LoadScene(menuScene);
    }


    void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
        tilemapObj = Instantiate(tilemapPrefab);
        inventoryObj = Instantiate(inventoryPrefab);
        inventoryObj.GetComponent<InventoryManager>().invCounts = inventory;
        inventoryObj.GetComponent<InventoryManager>().map = tilemapObj.transform.GetChild(0).GetComponent<Tilemap>();
        inventoryObj.GetComponent<InventoryManager>().instatiateReticle();
        if (curLevel == 1) {
            instantiateGenerator(new Vector3(-6, 3, 0), half, half);
            instantiateReceiver(new Vector3(5, 0, 0), half, half, 10);
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
