using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public GameObject winScreeenUI;

    private GameObject[] objects;
    // Start is called before the first frame update
    private bool CheckWin()
    {
        objects = FindObjectsOfType<GameObject>();

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].tag == "receiver")
            {
                if (!objects[i].GetComponent<ReceiverManager>().CheckFull())
                    return false;
            }
        }
        return true;
    }

    private void Update()
    {
        if (CheckWin())
            winScreeenUI.SetActive(true);
    }
}
