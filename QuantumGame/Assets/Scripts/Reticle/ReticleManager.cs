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

    public GameObject gatePrefab;
    public GameObject beltPrefab;
    public GameObject doublePrefab;


    public int prefabDirection;
    public int prefabType;

    public AdvancedRuleTile[] tiles;
    public Tilemap map;
/*    public AdvancedRuleTile belt;*/

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
        prefabDirection++;
        if (prefabDirection > 3) prefabDirection = 0;
    }

    private void RotateCCW()
    {
        prefabDirection--;
        if (prefabDirection < 0) prefabDirection = 3;
    }

    private void PlaceUnitary(GameObject prefab, int direction, int type = -1) {

        if (boxCollider.IsTouchingLayers(LayerMask.GetMask("Placeable", "Unplaceable","Belt")))
        {
            Debug.Log("Blocked");
            return;
        }
        Vector3 spawn = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject obj = Instantiate(prefab, spawn, Quaternion.identity);
        if (type == -1)
        {
            obj.GetComponent<BeltManager>().direction = direction;
            Vector3 vec = transform.position;
            map.SetTile(new Vector3Int((int)vec.x, (int)vec.y, (int)vec.z), tiles[direction]);

        }
        else {
            obj.GetComponent<GateManager>().gate = type;
            obj.GetComponentInChildren<BeltManager>().direction = direction;
        }
    }

    private void PlaceDouble(GameObject prefab, int direction, int type) {

        BoxCollider2D collider;

        if (direction == 0 || direction == 2)
            collider = transform.GetChild(1).GetComponent<BoxCollider2D>();
        else
            collider = transform.GetChild(0).GetComponent<BoxCollider2D>();

        if (collider.IsTouchingLayers(LayerMask.GetMask("Placeable", "Unplaceable", "Belt")))
        {
            Debug.Log("Blocked");
        }

        else
        {
            Vector3 spawn = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject obj = Instantiate(prefab, spawn, Quaternion.identity);

            obj.GetComponent<DoubleGateManager>().gate = type;
            obj.GetComponent<DoubleGateManager>().direction = direction;
        }

        boxCollider.size = new Vector2(0.8f, 0.8f);
        boxCollider.offset = new Vector2(0, 0);


    }

/*    private void PlaceBelt(AdvancedRuleTile belt) {
        if (boxCollider.IsTouchingLayers(LayerMask.GetMask("Placeable", "Unplaceable","Belt")))
        {
            Debug.Log("Blocked");
        }
        else {
            Vector3 vec = transform.position;
            map.SetTile(new Vector3Int((int)vec.x, (int)vec.y, (int)vec.z), belt);
        }
    
    }*/


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
            PlaceUnitary(gatePrefab, prefabDirection, prefabType);
        if (Input.GetKey("c"))
            PlaceUnitary(beltPrefab, prefabDirection);
        if (Input.GetKey("x"))
            RemovePlaceable();
        if (Input.GetKey("b"))
        {
            PlaceDouble(doublePrefab, prefabDirection, prefabType);
        }
    }

}
