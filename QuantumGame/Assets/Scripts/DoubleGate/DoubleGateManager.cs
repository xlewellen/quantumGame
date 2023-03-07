using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGateManager : MonoBehaviour
{
    public int gate;

    public int direction;

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void SwapGate(GameObject c1, GameObject c2) {
        float tmp0 = c1.GetComponent<DoubleGateCatch>().caughtAlpha;
        float tmp1 = c1.GetComponent<DoubleGateCatch>().caughtBeta;
        float tmp2 = c2.GetComponent<DoubleGateCatch>().caughtAlpha;
        float tmp3 = c2.GetComponent<DoubleGateCatch>().caughtBeta;

        c1.GetComponent<DoubleGateCatch>().caughtAlpha = tmp2;
        c1.GetComponent<DoubleGateCatch>().caughtBeta = tmp3;
        c2.GetComponent<DoubleGateCatch>().caughtAlpha = tmp0;
        c2.GetComponent<DoubleGateCatch>().caughtBeta = tmp1;
    }

    private void ApplyGate(GameObject c1, GameObject c2)
    {
        if (gate == 0) {
            SwapGate(c1, c2);
        }
        c1.GetComponent<DoubleGateCatch>().Release();
        c2.GetComponent<DoubleGateCatch>().Release();
    }

    private void SwitchSprite() {
        if (direction == 0 || direction == 2)
            spriteRenderer.sprite = sprites[0];
        else
            spriteRenderer.sprite = sprites[1];
    }
    private void switchChildren() {
        GameObject c1 = transform.GetChild(0).gameObject;
        GameObject c2 = transform.GetChild(1).gameObject;
        if (direction == 1 || direction == 3)
        {
            c1.transform.localPosition = new Vector3(-1, 0, 0);
            transform.GetComponent<BoxCollider2D>().size = new Vector2(2, 1);
            transform.GetComponent<BoxCollider2D>().offset = new Vector2(-0.5f, 0);
        }
        else {
            c1.transform.localPosition = new Vector3(0, 1, 0);
            transform.GetComponent<BoxCollider2D>().size = new Vector2(1, 2);
            transform.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0.5f);
        }
    }

    private void Update()
    {
        SwitchSprite();
        switchChildren();

        GameObject c1 = transform.GetChild(0).gameObject;
        GameObject c2 = transform.GetChild(1).gameObject;

        if (c1.GetComponent<DoubleGateCatch>().AnyCaught() && c2.GetComponent<DoubleGateCatch>().AnyCaught())
            ApplyGate(c1, c2);

    }

}
