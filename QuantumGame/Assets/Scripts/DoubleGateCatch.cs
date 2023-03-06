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

   
    private void Start()
    {
        caught = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Catch(col.gameObject);
    }

    public void Catch(GameObject obj) {
        caughtAlpha = obj.GetComponent<ObjectManager>().alpha;
        caughtBeta = obj.GetComponent<ObjectManager>().beta;

        obj.GetComponent<ObjectManager>().Remove();

        caught = true;
    }   
    public GameObject Release() {
        Vector3 spawn = new Vector3(transform.position.x + (0.3f), transform.position.y, transform.position.z);
        GameObject obj = Instantiate(objPrefab, spawn, Quaternion.identity);

        obj.GetComponent<ObjectManager>().alpha = caughtAlpha;
        obj.GetComponent<ObjectManager>().beta = caughtBeta;

        caught = false;

        return obj;
    }

    public bool AnyCaught() {
        return caught;
    }

}
