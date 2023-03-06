using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ReticleManager : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private double rotatecounter;
    private double counter;
    private double moveTime = 0.1;
    public GameObject objPrefab;
    public int objDirection;
    public int objType;
    public Tilemap map;
    public AdvancedRuleTile belt;

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private float gridSet(float num) {

        return Mathf.Ceil(num);
    }

    private void PlayerMove() {
        if (counter < moveTime) counter += Time.deltaTime;

        moveDelta = Vector3.zero;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0);

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), 1, LayerMask.GetMask("Reticle", "Blocking"));
        if (hit.collider != null) moveDelta.y = 0;
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), 1, LayerMask.GetMask("Reticle", "Blocking"));
        if (hit.collider != null) moveDelta.x = 0;
        if (counter >= moveTime)
        {

            transform.Translate(gridSet(moveDelta.x), gridSet(moveDelta.y), 0);
            counter = 0;

        }
    }

    private void Rotate() {

        if (rotatecounter < moveTime) rotatecounter += Time.deltaTime;

        bool cw = Input.GetKey("t");
        bool ccw = Input.GetKey("r");

        if (rotatecounter >= moveTime && cw) {
            RotateCW();
            rotatecounter = 0;
        }
        if (rotatecounter >= moveTime && ccw) {
            RotateCCW();
            rotatecounter = 0;
        }
    }

    private void RotateCW()
    {
        objDirection++;
        if (objDirection > 3) objDirection = 0;
    }

    private void RotateCCW()
    {
        objDirection--;
        if (objDirection < 0) objDirection = 3;
    }

    private void PlaceGate(GameObject objPrefab, int type, int direction) {
        
        if (boxCollider.IsTouchingLayers(LayerMask.GetMask("Placeable", "Unplaceable")))
        {
            Debug.Log("Blocked");
        }
        else {
            RemovePlaceable();
            Vector3 spawn = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject obj = Instantiate(objPrefab, spawn, Quaternion.identity);
            obj.GetComponent<GateManager>().gate = type;
            obj.GetComponentInChildren<BeltManager>().direction = direction;
        }
    }

    private void PlaceBelt(AdvancedRuleTile belt) {
        Vector3 vec = transform.position;
        map.SetTile(new Vector3Int((int) vec.x, (int)vec.y, (int)vec.z), belt);
    
    }

    private void RemovePlaceable() {
        Collider2D[] contacts = new Collider2D[10];
        ContactFilter2D layers = new ContactFilter2D();
        layers.SetLayerMask(LayerMask.GetMask("Placeable","Belt"));
        layers.useLayerMask = true;
        layers.useTriggers = true;

        int count = boxCollider.GetContacts(layers, contacts);
        Debug.Log(count);
        for (int i = 0; i < count; i++)
        {
            Destroy(contacts[i].gameObject);
        }

        Vector3 vec = transform.position;
        map.SetTile(new Vector3Int((int)vec.x, (int)vec.y, (int)vec.z), null);
    }

    private void FixedUpdate()
    {
        PlayerMove();
        Rotate();
        if (Input.GetKey("z"))
            PlaceGate(objPrefab, objType, objDirection);
        if (Input.GetKey("c"))
            PlaceBelt(belt);
        if (Input.GetKey("x"))
            RemovePlaceable();
    }

}
