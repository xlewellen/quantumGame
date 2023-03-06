using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ReceiverManager : MonoBehaviour
{
    public float targetalpha;
    public float targetbeta;

    private int count = 0;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Object")
        {
            IterateCount(col.gameObject);
            Debug.Log(GetCount());

            col.gameObject.GetComponent<ObjectManager>().Remove();
        }
    }

    private void IterateCount(GameObject obj) {
        float alpha = obj.GetComponent<ObjectManager>().alpha;
        float beta = obj.GetComponent<ObjectManager>().beta;

        if (alpha == targetalpha && beta == targetbeta) count++;
    }

    private int GetCount() {
        return count;
    }

}
