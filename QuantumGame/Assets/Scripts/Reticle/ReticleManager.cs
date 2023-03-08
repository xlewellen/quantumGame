using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ReticleManager : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    
    private double counter;
    private double rotatecounter;
    private double moveTime = 0.1;

    public int prefabDirection;
    public int prefabType;

    private Vector3 lastSpawn;

    public AdvancedRuleTile[] tiles;
    public Tilemap map;

    private GameObject[] objects;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        addBelts();
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

        bool cw = Input.GetKey("e");
        bool ccw = Input.GetKey("q");

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

    private void addBelts()
    {
        objects = FindObjectsOfType<GameObject>();

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].tag == "generator")
            {
                Vector3 vec = objects[i].transform.position;
                map.SetTile(new Vector3Int((int)vec.x, (int)vec.y, (int)vec.z), tiles[0]);
            }
        }
    }

    public bool PlaceUnitary(GameObject prefab, int type = -1) {
        Vector3 spawn = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (boxCollider.IsTouchingLayers(LayerMask.GetMask("Placeable", "Unplaceable", "Belt", "Blocking")) || lastSpawn == spawn)
        {
            return false;
        }
        lastSpawn = spawn;
        GameObject obj = Instantiate(prefab, spawn, Quaternion.identity);
        if (type == -1)
        {
            obj.GetComponent<BeltManager>().direction = prefabDirection;

        }
        else {
            obj.GetComponent<GateManager>().gate = type;
            obj.GetComponentInChildren<BeltManager>().direction = prefabDirection;
        }
        Vector3 vec = transform.position;
        map.SetTile(new Vector3Int((int)vec.x, (int)vec.y, (int)vec.z), tiles[prefabDirection]);

        return true;
    }

    public bool PlaceDouble(GameObject prefab, int type) {

        BoxCollider2D collider;
        bool success = true;

        if (prefabDirection == 0 || prefabDirection == 2)
            collider = transform.GetChild(1).GetComponent<BoxCollider2D>();
        else
            collider = transform.GetChild(0).GetComponent<BoxCollider2D>();

        Vector3 spawn = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (collider.IsTouchingLayers(LayerMask.GetMask("Placeable", "Unplaceable", "Belt", "Blocking")) || lastSpawn == spawn)
        {
            success = false;
        }

        else
        {
            lastSpawn = spawn;
            GameObject obj = Instantiate(prefab, spawn, Quaternion.identity);

            obj.GetComponent<DoubleGateManager>().gate = type;
            obj.GetComponent<DoubleGateManager>().direction = prefabDirection;
        }

        boxCollider.size = new Vector2(0.8f, 0.8f);
        boxCollider.offset = new Vector2(0, 0);

        return success;
    }


    public int RemovePlaceable() {
        int index = -1;

        lastSpawn = new Vector3(-100, -100, 0);

        Collider2D[] contacts = new Collider2D[3];
        ContactFilter2D layers = new ContactFilter2D();
        layers.SetLayerMask(LayerMask.GetMask("Placeable"));
        layers.useLayerMask = true;
        layers.useTriggers = true;

        int count = boxCollider.GetContacts(layers, contacts);
        for (int i = 0; i < count; i++)
        {
            string tag = contacts[i].gameObject.tag;
            if (tag == "belt")
                index = 0;
            if (tag == "single")
                index = contacts[i].gameObject.GetComponent<GateManager>().gate + 1;
            if (tag == "double")
                index = 5;
            Destroy(contacts[i].gameObject);
        }

        Vector3 vec = transform.position;
        map.SetTile(new Vector3Int((int)vec.x, (int)vec.y, (int)vec.z), null);

        return index;
    }
    private void DestroyAllGameObjects()
    {
        //gather all game objects
        GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

        for (int i = 0; i < GameObjects.Length; i++)
        {
            //layer 12
            if (GameObjects[i].gameObject.layer == 12 ||
                GameObjects[i].gameObject.layer == 13 ||
                GameObjects[i].gameObject.tag == "Object") {
            //delete obj if tagged as gate or belt
                Debug.Log("gameObject deleted: " + GameObjects[i]);
                Destroy(GameObjects[i]);
            }
        }
        //clear tilemap
        Debug.Log("tilemap cleared: " + map);
        map.ClearAllTiles();
    }
    private void FixedUpdate()
    {
        PlayerMove();
        Rotate();
    }

}
