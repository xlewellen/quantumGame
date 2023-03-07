using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private GameObject parent;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        parent = transform.parent.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        SpriteUpdate();
    }

    private void SpriteUpdate()
    {
        int dir = parent.GetComponent<ReticleManager>().prefabDirection;
        spriteRenderer.sprite = sprites[dir];
    }
}
