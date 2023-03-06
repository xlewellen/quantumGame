using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGateManager : MonoBehaviour
{
    public int gate;
    // Start is called before the first frame update

    /*    private Matrix4x4 GetGate() {
            Matrix4x4 g = new Matrix4x4();

            switch (gate) {
                case 0:
                    g.SetRow(0, new Vector4(1, 0, 0, 0));
                    g.SetRow(1, new Vector4(0, 0, 1, 0));
                    g.SetRow(2, new Vector4(0, 1, 0, 0));
                    g.SetRow(3, new Vector4(0, 0, 0, 1));
                    break;
                case 1:
                    g.SetRow(0, new Vector4(1, 0, 0, 0));
                    g.SetRow(1, new Vector4(0, 1, 0, 0));
                    g.SetRow(2, new Vector4(0, 0, 0, 1));
                    g.SetRow(3, new Vector4(0, 0, 1, 0));
                    break;
            }

            return g;
        }

        private Vector4 GetVector(float a, float b, float c, float d) {
            return new Vector4(a * c, a * d, b * c, b * d);
        }*/

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

    private void Update()
    {
        GameObject c1 = transform.GetChild(0).gameObject;
        GameObject c2 = transform.GetChild(1).gameObject;

        if (c1.GetComponent<DoubleGateCatch>().AnyCaught() && c2.GetComponent<DoubleGateCatch>().AnyCaught())
            ApplyGate(c1, c2);

    }

}
