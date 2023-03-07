using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltManager : MonoBehaviour
{

    // TODO: determine direction based on what tile the belt is assigned

    private Vector3 vec;

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    public int direction;

    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private Vector3 GetDifference(GameObject obj) {
        Vector3 dir = transform.position - obj.transform.position;
        if (direction == 0 || direction == 2)
            dir.x = 0;
        else
            dir.y = 0;
        return 5*dir;
    }

    private void SwitchTexture() {
        spriteRenderer.sprite = sprites[direction];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SwitchTexture();
        switch (direction)
        {
            case 0:
                vec = new Vector3(1, 0, 0);
                break;
            case 1:
                vec = new Vector3(0, -1, 0);
                break;
            case 2:
                vec = new Vector3(-1, 0, 0);
                break;
            case 3:
                vec = new Vector3(0, 1, 0);
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Object")
        {
            Vector3 dif = GetDifference(other.gameObject);
            other.gameObject.GetComponent<ObjectManager>().SetDir(dif + vec);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Object")
            other.gameObject.GetComponent<ObjectManager>().SetDir(new Vector3(0,0,0));
    }

}