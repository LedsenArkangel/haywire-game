using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    Animator animator;
    BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enable(bool b)
    {
        collider.enabled = b;
        if (!b)
        {
            animator.speed = -1.0F;
            animator.Play("openning");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        animator.speed = 1.0F;
        animator.Play("openning");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        animator.speed = -1.0F;
        animator.Play("openning");
    }
}
