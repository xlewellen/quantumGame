using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    private int[] invCounts;
    // Start is called before the first frame update

    public void setCounts(int[] counts) {
        invCounts = counts;
    }


    
    void Start()
    {
        int[] inventory = new int[6];
        inventory[0] = 1;
        inventory[1] = 2;
        inventory[2] = 3;
        inventory[3] = 4;
        inventory[4] = 5;
        inventory[5] = 6;
        setCounts(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
