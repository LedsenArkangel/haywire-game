using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyBehavior : MonoBehaviour
{
    public AudioClip sfx;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player" && Input.GetAxis("Jump") != 0) {
            audio.PlayOneShot(sfx);
        }
    }
}
