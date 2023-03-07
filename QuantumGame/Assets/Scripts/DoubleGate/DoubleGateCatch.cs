using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DoubleGateCatch : MonoBehaviour
{

    public GameObject objPrefab;

    // Start is called before the first frame update
    public float caughtAlpha;
    public float caughtBeta;
    private bool caught;
    private Vector3 pos;
   
    private void Start()
    {
        caught = false;
    }

    private void Update()
    {
        int dir = transform.parent.GetComponent<DoubleGateManager>().direction;
        transform.GetChild(0).GetComponent<BeltManager>().direction = dir;
        if (dir == 0) {
            pos.x = 0.3f;
            pos.y = 0f;
        }
        else if (dir == 1)
        {
            pos.x = 0f;
            pos.y = -0.3f;
        }
        else if (dir == 2)
        {
            pos.x = -0.3f;
            pos.y = 0f;
        }
        else
        {
            pos.x = 0f;
            pos.y = 0.3f;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Object")
            Catch(col.gameObject);
    }

    public void Catch(GameObject obj) {
        caughtAlpha = obj.GetComponent<ObjectManager>().alpha;
        caughtBeta = obj.GetComponent<ObjectManager>().beta;

        obj.GetComponent<ObjectManager>().Remove();

        caught = true;
    }   
    public GameObject Release() {
        Vector3 spawn = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject obj = Instantiate(objPrefab, spawn + pos, Quaternion.identity);

        obj.GetComponent<ObjectManager>().alpha = caughtAlpha;
        obj.GetComponent<ObjectManager>().beta = caughtBeta;

        caught = false;

        return obj;
    }

    public bool AnyCaught() {
        return caught;
    }

}
