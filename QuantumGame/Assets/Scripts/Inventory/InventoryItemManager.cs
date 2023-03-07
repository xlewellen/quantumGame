using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemManager : MonoBehaviour
{

    private GameObject parent;
    public int index;
    private string count;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        count = (parent.GetComponent<InventoryManager>().invCounts[index]).ToString();
        transform.GetChild(2).GetComponent<Text>().text = count;
        if (parent.GetComponent<InventoryManager>().invSelect == index)
            GetComponent<Image>().color = Color.green;
        else
            GetComponent<Image>().color = Color.white;
    }
}
