using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InventoryManager : MonoBehaviour
{
    public GameObject reticlePrefab;
    public GameObject gatePrefab;
    public GameObject beltPrefab;
    public GameObject doublePrefab;
    public Tilemap map;
    private GameObject reticle;

    public int invSelect;
    public int[] invCounts;

    private double rotatecounter;
    private double moveTime = 0.2;
    // Start is called before the first frame update

    public void setCounts(int[] counts) {
        for (int i = 0; i < 6; i++)
            invCounts[i] = counts[i];
    }


    
    void Start()
    {
        int[] inventory = new int[6];
        for (int i = 0; i < 6; i++)
            inventory[i] = 100;
        invCounts = inventory;

        invSelect = 0;

        reticle = Instantiate(reticlePrefab, new Vector3(0,0,0), Quaternion.identity);
        reticle.GetComponent<ReticleManager>().map = map;

    }

    private void Rotate()
    {

        if (rotatecounter < moveTime) rotatecounter += Time.deltaTime;

        bool cw = Input.GetKey("l");
        bool ccw = Input.GetKey("j");

        if (rotatecounter >= moveTime && cw)
        {
            RotateCW();
            rotatecounter = 0;
        }
        if (rotatecounter >= moveTime && ccw)
        {
            RotateCCW();
            rotatecounter = 0;
        }
    }

    private void RotateCW()
    {
        invSelect++;
        if (invSelect > 5) invSelect = 0;
    }

    private void RotateCCW()
    {
        invSelect--;
        if (invSelect < 0) invSelect = 5;
    }
    private void place() {
        if (invCounts[invSelect] > 0)
        {
            bool success;

            if (invSelect == 0)
                success = reticle.GetComponent<ReticleManager>().PlaceUnitary(beltPrefab);
            else if (invSelect == 5)
                success = reticle.GetComponent<ReticleManager>().PlaceDouble(doublePrefab, 0);
            else
               success = reticle.GetComponent<ReticleManager>().PlaceUnitary(gatePrefab, invSelect - 1);

            if (success)
                invCounts[invSelect]--;
        }

    }

    private void remove()
    {
        int index = reticle.GetComponent<ReticleManager>().RemovePlaceable();
        if (index != -1)
            invCounts[index]++;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rotate();
        if (Input.GetKey("z"))
            place();
        if (Input.GetKey("x"))
            remove();
        /*        if (Input.GetKey("c"))
                    PlaceUnitary(beltPrefab, prefabDirection);
                if (Input.GetKey("x"))
                    RemovePlaceable();
                if (Input.GetKey("b"))
                {
                    PlaceDouble(doublePrefab, prefabDirection, prefabType);
                }*/
    }
}