using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public float alpha;
    public float beta;
    public bool kill = true;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private Vector3 direction;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        direction = new Vector3(0, 0, 0);

        if (kill)
            Destroy(gameObject, 100);

    }

    private void FixedUpdate()
    {
        SpriteUpdate();
        Move(direction);
        if (kill)
            transform.rotation = Quaternion.identity;
    }

    private void Move(Vector3 vec) {
        transform.Translate(vec.x * Time.deltaTime, vec.y * Time.deltaTime, 0);
    }


    public void SetDir(Vector3 vec) {
        direction = vec;
    }


    private void SpriteUpdate() {
        if ((alpha == 1f || alpha == -1f) && beta == 0f) spriteRenderer.sprite = sprites[0];
        else if (alpha == 0f && (beta == 1f || beta == -1f)) spriteRenderer.sprite = sprites[1];
        else if ((alpha > 0 && beta > 0) || (alpha < 0 && beta < 0)) spriteRenderer.sprite = sprites[2];
        else spriteRenderer.sprite = sprites[3];
    }

    private void round()
    {
        if (Mathf.Abs(alpha) < 0.01) alpha = 0f;
        if (Mathf.Abs(beta) < 0.01) beta = 0f;

        if (alpha > 0.99) alpha = 1f;
        if (beta > 0.99) beta = 1f;

        if (alpha < -0.99) alpha = -1f;
        if (beta < -0.99) beta = -1f;
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
        round();
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

    public void Remove()
    {
        Destroy(gameObject);
    }



}
