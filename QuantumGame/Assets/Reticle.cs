using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private double counter;

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void MoveWait(double time) {
        double counter = 0.0;
        while (counter < time) {
            counter += Time.deltaTime;
        }
        return;
    }

    private float gridSet(float num) {

        return Mathf.Ceil(num);
    }

    private void FixedUpdate()
    {
        //Reset MoveDelta

        double moveTime = 0.1;
        
        if (counter < moveTime) counter += Time.deltaTime;

        moveDelta = Vector3.zero;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0);

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), 1, LayerMask.GetMask("Reticle", "Blocking"));
        if (hit.collider != null) moveDelta.y = 0;
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), 1, LayerMask.GetMask("Reticle", "Blocking"));
        if (hit.collider != null) moveDelta.x = 0;
        if (counter >= moveTime) {

            transform.Translate(gridSet(moveDelta.x), gridSet(moveDelta.y), 0);
            counter = 0;

        }

        /*        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Reticle", "Blocking"));
                if (hit.collider == null && counter >= moveTime)
                {

                    transform.Translate(Mathf.Ceil(moveDelta.x), 0, 0);
                    counter = 0;

                }*/

        /*var currentPos = transform.position;
        transform.position = new Vector3(Mathf.Round(currentPos.x), Mathf.Round(currentPos.y), Mathf.Round(currentPos.z));*/

    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -4, 3);
        viewPos.y = Mathf.Clamp(viewPos.y, -3, 2);
        transform.position = viewPos;
    }
}
