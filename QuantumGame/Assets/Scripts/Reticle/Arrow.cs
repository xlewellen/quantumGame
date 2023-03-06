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
        int dir = parent.GetComponent<ReticleManager>().objDirection;
        if (dir == 0) spriteRenderer.sprite = sprites[0];
        else if (dir == 1) spriteRenderer.sprite = sprites[1];
        else if (dir == 2) spriteRenderer.sprite = sprites[2];
        else spriteRenderer.sprite = sprites[3];
    }
}
