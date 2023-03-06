using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltManager : MonoBehaviour
{

    // TODO: determine direction based on what tile the belt is assigned

    private int RIGHT = 0;
    private int LEFT = 1;
    private int UP = 2;
    private int DOWN = 3;

    // the resource on the belt
    GameObject resource;

    public int direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = DOWN;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        switch (direction) {
            case 0 :
                resource.transform.Translate(1 * Time.deltaTime ,0,0);
                break;
            case 1 :
                resource.transform.Translate(-1 * Time.deltaTime ,0,0);
                break;
            case 2 :
                resource.transform.Translate(0,1 * Time.deltaTime,0);
                break;
            case 3 :
                resource.transform.Translate(0,-1 * Time.deltaTime,0);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Object")
            resource = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Object")
            resource = null;
    }
}
