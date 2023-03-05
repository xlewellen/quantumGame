using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public float alpha;
    public float beta;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        SpriteUpdate();
        transform.Translate(1*Time.deltaTime, 0, 0);
    }

    private void SpriteUpdate() {
        if (alpha == 1f && beta == 0f) spriteRenderer.sprite = sprites[0];
        else if (alpha == 0f && beta == 1f) spriteRenderer.sprite = sprites[1];
        else if (alpha > 0 && beta > 0) spriteRenderer.sprite = sprites[2];
        else spriteRenderer.sprite = sprites[3];
    }

    private void round()
    {
        if (Mathf.Abs(alpha) < 0.00001)
            alpha = 0f;
        if (Mathf.Abs(beta) < 0.00001)
            alpha = 0f;

        if (alpha > 0.98)
            alpha = 1f;
        if (beta > 0.9999)
            beta = 1f;

        if (alpha < -0.9999)
            alpha = -1f;
        if (beta < -0.9999)
            beta = -1f;
    }

    public void NotGate() {
        float temp = alpha;
        alpha = beta;
        beta = temp;

    }

    public void HGate() {
        float half = 1 / Mathf.Sqrt(2);
        float temp0 = alpha;
        float temp1 = beta;
        alpha = (temp0 * half) + (temp1 * half);
        beta = (temp0 * half) - (temp1 * half);
    }

    public void ZGate() {
        if (beta != 0) 
            beta *= -1;
    }

    public void Measure() {
        float percent = Mathf.Pow(Mathf.Abs(alpha), 2);
        float compare = Random.Range(0f, 1f);

        if (compare <= percent)
        {
            alpha = 1f;
            beta = 0f;
        }
        else {
            alpha = 0f;
            beta = 1f;
        }
    }


}
