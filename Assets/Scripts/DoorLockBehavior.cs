using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockBehavior : MonoBehaviour
{
    Animator animator;
    AudioSource audio;
    public DoorBehavior door;
    public AudioClip sfxUnlock;
    public AudioClip sfxLock;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player" && Input.GetAxis("Jump") != 0) {
            if (door.isLocked) {
                if (Inventory.GetSelectedItemName() == "ID Card") {
                    door.Lock(false);
                    animator.SetTrigger("unlocking");
                    audio.PlayOneShot(sfxUnlock);
                } else {
                    audio.PlayOneShot(sfxLock);
                    Fungus.Flowchart.BroadcastFungusMessage("DeniedAccess");
                }
            }
        }
    }
}
