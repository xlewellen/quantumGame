using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GateManager : MonoBehaviour
{


    public int gate;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;


    private void Start()
    {
        SpriteUpdate();
    }

    private void SpriteUpdate()
    {
        if (gate == 0) spriteRenderer.sprite = sprites[0];
        else if (gate == 1) spriteRenderer.sprite = sprites[1];
        else if (gate == 2) spriteRenderer.sprite = sprites[2];
        else spriteRenderer.sprite = sprites[3];
    }


    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Object")
        {
            switch (gate)
            {
                case 0:
                    obj.gameObject.GetComponent<ObjectManager>().NotGate();
                    break;
                case 1:
                    obj.gameObject.GetComponent<ObjectManager>().HGate();
                    break;
                case 2:
                    obj.gameObject.GetComponent<ObjectManager>().ZGate();
                    break;
                case 3:
                    obj.gameObject.GetComponent<ObjectManager>().Measure();
                    break;
            }
        }
    }
}
