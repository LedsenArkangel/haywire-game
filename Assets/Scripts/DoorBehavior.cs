using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    Animator animator;
    public bool isLocked = true;
    public EdgeCollider2D warp;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        warp.enabled = !isLocked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lock(bool b)
    {
        isLocked = b;
        warp.enabled = !isLocked;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isLocked) {
            animator.SetBool("isOpened", true);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!isLocked) {
            animator.SetBool("isOpened", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!isLocked) {
            animator.SetBool("isOpened", false);
        }
    }
}
