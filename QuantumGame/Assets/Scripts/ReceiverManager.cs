using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReceiverManager : MonoBehaviour
{
    public float targetalpha;
    public float targetbeta;

    public int count = 0;
    public int target = 10;
    private float half = 1f / Mathf.Sqrt(2f);
    public bool CheckFull() {
        if (count >= target)
            return true;
        return false;
    }

    private void Update()
    {
        if (targetalpha == 2f)
            targetalpha = half;
        if (targetbeta == 2f)
            targetbeta = half;
        if (targetalpha == -2f)
            targetalpha = half * -1f;
        if (targetbeta == -2f)
            targetbeta = half * -1f;

        transform.GetChild(0).gameObject.GetComponent<ObjectManager>().alpha = targetalpha;
        transform.GetChild(0).gameObject.GetComponent<ObjectManager>().beta = targetbeta;

        transform.GetChild(2).GetChild(2).GetComponent<Text>().text = target.ToString();
        transform.GetChild(2).GetChild(0).GetComponent<Text>().text = count.ToString();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Object")
        {
            IterateCount(col.gameObject);

            col.gameObject.GetComponent<ObjectManager>().Remove();
        }
    }

    private void IterateCount(GameObject obj) {
        float alpha = obj.GetComponent<ObjectManager>().alpha;
        float beta = obj.GetComponent<ObjectManager>().beta;

        if (alpha == targetalpha && beta == targetbeta && count < target) {
            count++;
        }
    }



}
