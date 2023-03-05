using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{

    public GameObject objPrefab;
    private float spawnDelay = 2f;
    public float timeCount = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    GameObject spawnObj() {
        Vector3 spawn = new Vector3(transform.position.x + (0.5f), transform.position.y, transform.position.z);
        GameObject obj = Instantiate(objPrefab, spawn, Quaternion.identity);

        obj.GetComponent<ObjectManager>().alpha = 1f;
        obj.GetComponent<ObjectManager>().beta = 0f;

        return obj;
    }

    private void FixedUpdate()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= spawnDelay)
        {
            GameObject obj = spawnObj();
            obj.GetComponent<ObjectManager>().HGate();
            obj.GetComponent<ObjectManager>().HGate();

            timeCount = 0f;
        }
    }

}
