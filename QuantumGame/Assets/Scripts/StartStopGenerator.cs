using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStopGenerator : MonoBehaviour
{


    public GameObject[] generators;
    public GameObject[] objects;
    public GameObject[] receivers;

    // Start is called before the first frame update

    public void softReset()
    {
        objects = FindObjectsOfType<GameObject>();

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].tag == "Object")
            {
                objects[i].GetComponent<ObjectManager>().Remove();
            }
        }

        receivers = FindObjectsOfType<GameObject>();

        for (int i = 0; i < receivers.Length; i++)
        {
            if (receivers[i].tag == "receiver")
            {
                receivers[i].GetComponent<ReceiverManager>().count = 0; ;
            }
        }
    }

    [ContextMenu("Stop Gen")]
    public void StopGenerators() {
        generators = FindObjectsOfType<GameObject>();

        for (int i = 0; i < generators.Length; i++)
        {
            if (generators[i].tag == "generator")
            {
                generators[i].GetComponent<GeneratorManager>().isGenActive = false;
            }
        }

        softReset();

    }

    [ContextMenu("Start Gen")]
    public void StartGenerators() {
        generators = FindObjectsOfType<GameObject>();

        for (int i = 0; i < generators.Length; i++)
        {
            if (generators[i].tag == "generator")
            {
                generators[i].GetComponent<GeneratorManager>().isGenActive = true;
            }
        }
    }

}
