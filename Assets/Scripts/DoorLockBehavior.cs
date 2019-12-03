using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockBehavior : MonoBehaviour
{
    Animator animator;
    public bool isLocked = true;
    public DoorBehavior door;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        SetLock(isLocked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetLock(bool b)
    {
        door.Enable(b);
        if (b) {
            animator.speed = -0.2F;
            animator.Play("unlocking");
        } else {
            animator.speed = 0.2F;
            animator.Play("unlocking");
        }
    }
}
