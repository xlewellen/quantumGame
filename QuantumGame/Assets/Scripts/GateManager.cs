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
        switch (gate) {
            case 0:
                obj.gameObject.GetComponent<ObjectManager>().NotGate();
                break;
            case 1:
                Debug.Log(Mathf.Abs(obj.gameObject.GetComponent<ObjectManager>().alpha));
                Debug.Log(Mathf.Abs(obj.gameObject.GetComponent<ObjectManager>().beta));
                obj.gameObject.GetComponent<ObjectManager>().HGate();
                Debug.Log(obj.gameObject.GetComponent<ObjectManager>().alpha);
                Debug.Log(obj.gameObject.GetComponent<ObjectManager>().beta);
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
