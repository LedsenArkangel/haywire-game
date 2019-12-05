using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableBehavior : MonoBehaviour
{
    public Sprite broken;
    public string requiredItemName = "";
    public bool isDestroyed = false;
    public AudioClip sfxDestroyed;

    SpriteRenderer spriteRenderer;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
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
                audio.PlayOneShot(sfxDestroyed, 0.1F);
            }
        }
    }
}
