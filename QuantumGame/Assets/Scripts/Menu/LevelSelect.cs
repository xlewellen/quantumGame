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
        //if (Input.GetKey("k")) {
        //    DestroyAllGameObjects();
        //}
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



    // TODO: change menuScene with the approproate lvl variable
    // x: -6 to 5, y: -4 to 4
    public void One() {
        SceneManager.LoadScene("Level 1");
    }

    public void Two() {
        SceneManager.LoadScene("Level 2");
    }

    public void Three() {
        SceneManager.LoadScene("Level 3");
    }

    public void Four() {
        SceneManager.LoadScene("Level 4");
    }

    public void Five() {
        SceneManager.LoadScene("Level 5");
    }

    public void Six() {
        SceneManager.LoadScene("Level 6");
    }

    public void Seven() {
        SceneManager.LoadScene("Level 7");
    }

    public void Eight() {
        SceneManager.LoadScene("Level 8");
    }

    public void Nine() {
        SceneManager.LoadScene("Level 9");
    }

    public void Ten() {
        SceneManager.LoadScene("Level 10");
    }

// TODO: Add cases here to fill the inventory for each level
    private void makeInv(int lvl) {


        switch (lvl) {

            case 1:
                inventory[TRACKS] = 100;
                inventory[H_GATE] = 2;
                inventory[Z_GATE] = 3;
                inventory[NOT_GATE] = 4;
                inventory[M_GATE] = 5;
                inventory[SWAP_GATE] = 6;
                return;
        }

    }
    //public void DestroyAllGameObjects()
    //{
        // ;)
        //SceneManager.LoadScene(menuScene);
    //}
}
