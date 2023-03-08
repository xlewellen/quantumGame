using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStopGenerator : MonoBehaviour
{


    public GameObject[] generators = new GameObject[5];
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("Stop Gen")]
    public void StopGenerators() {

        for (int i = 0; i < generators.Length; i++) {
            generators[i].GetComponent<GeneratorManager>().isGenActive = false;
        }
    }

    [ContextMenu("Start Gen")]
    public void StartGenerators() {

        for (int i = 0; i < generators.Length; i++) {
            generators[i].GetComponent<GeneratorManager>().isGenActive = true;
        }
    }

}
