using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableBehavior : MonoBehaviour
{
    public Sprite broken;
    public string requiredItemName = "";
    public bool isDestroyed = false;

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D (Collider2D other) {
        if (other.tag == "Player" && Input.GetAxis("Jump") != 0) {
            if (requiredItemName == "" || Inventory.GetSelectedItemName() == requiredItemName) {
                isDestroyed = true;
                spriteRenderer.sprite = broken;
            }
        }
    }
}
