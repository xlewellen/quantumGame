using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemManager : MonoBehaviour
{

    private GameObject parent;
    public int index;
    private string count;

    private Image spriteRenderer;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.parent.gameObject;
        spriteRenderer = transform.GetComponent<Image>();
    }

    private void SwitchTexture()
    {
        spriteRenderer.sprite = sprites[index];
    }

    // Update is called once per frame
    void Update()
    {
        SwitchTexture();

        count = (parent.GetComponent<InventoryManager>().invCounts[index]).ToString();
        transform.GetChild(0).GetComponent<Text>().text = count;
        if (parent.GetComponent<InventoryManager>().invSelect != index)
            GetComponent<Image>().color = Color.gray;
        else
            GetComponent<Image>().color = Color.white;
    }
}
