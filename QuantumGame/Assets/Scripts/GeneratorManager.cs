using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{

    public GameObject objPrefab;
    private float spawnDelay = 2f;
    private float timeCount = 0f;

    public float targetalpha;
    public float targetbeta;
    private float half = 1f / Mathf.Sqrt(2f);

    public bool isGenActive;

    // Start is called before the first frame update
    void Start()
    {
        isGenActive = false;
    }

    GameObject spawnObj() {
        Vector3 spawn = new Vector3(transform.position.x + (0.5f), transform.position.y, transform.position.z);
        GameObject obj = Instantiate(objPrefab, spawn, Quaternion.identity);

        obj.GetComponent<ObjectManager>().alpha = targetalpha;
        obj.GetComponent<ObjectManager>().beta = targetbeta;

        return obj;
    }

    private void FixedUpdate()
    {
        if (targetalpha == 2f)
            targetalpha = half;
        if (targetbeta == 2f)
            targetbeta = half;
        if (targetalpha == -2f)
            targetalpha = half * -1f;
        if (targetbeta == -2f)
            targetbeta = half * -1f;

        timeCount += Time.deltaTime;
        if (timeCount >= spawnDelay && isGenActive)
        {
            GameObject obj = spawnObj();

            timeCount = 0f;
        }

        transform.GetChild(0).gameObject.GetComponent<ObjectManager>().alpha = targetalpha;
        transform.GetChild(0).gameObject.GetComponent<ObjectManager>().beta = targetbeta;
    }

    [ContextMenu("Stop Gen")]
    public void StopGenerators() {
        isGenActive = false;
    }

    [ContextMenu("Start Gen")]
    public void StartGenerators() {
        isGenActive = true;
    }

}
