using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DestroyableItem : MonoBehaviour
{
    public Flowchart flowchart;
    public Sprite damagedSprite;
    public AudioClip soundEffect;
    AudioSource source;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        source = this.GetComponent<AudioSource>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other) {
        if (Input.GetButtonDown("Jump"))
        {
            spriteRenderer.sprite = damagedSprite;
            source.PlayOneShot(soundEffect);
            flowchart.SetBooleanVariable("DestroyedServer" + this.gameObject.name, true);
            flowchart.SendFungusMessage("CheckServer");
        }
    }
}
