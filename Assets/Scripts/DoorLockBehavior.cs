using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockBehavior : MonoBehaviour
{
    Animator animator;
    public DoorBehavior door;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player" && Input.GetAxis("Jump") != 0) {
            if (door.isLocked && Inventory.GetSelectedItemName() == "ID Card") {
                door.Lock(false);
                animator.SetTrigger("unlocking");
            }
        }
    }
}
