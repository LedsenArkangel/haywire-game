using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator animator;
    Rigidbody2D rigidbody;
    BoxCollider2D collider;
    Inventory inventory;

    public float speed = 7;
    public float jump = 100;
    public float minJump = 10;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") < 0) {
            // left
            spriteRenderer.flipX = true;
        } else if (Input.GetAxis("Horizontal") > 0) {
            // right
            spriteRenderer.flipX = false;
        }

        if (Input.GetAxis("Jump") != 0) {
            // interact
            animator.Play("interacting");
        }
    }

    // Update is called at constant rate independent of frame rate
    void FixedUpdate()
    {
        // Horizontal movement
        var horizontalSpeed = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.position += new Vector3(horizontalSpeed, 0, 0);
        animator.SetFloat("horizontal", Mathf.Abs(horizontalSpeed));

        // Jump
        var verticalSpeed = rigidbody.velocity.y;
        animator.SetFloat("vertical", verticalSpeed);
        if (Input.GetAxis("Vertical") > 0 && verticalSpeed == 0) {
            var jumpForce = Input.GetAxis("Vertical") * jump * minJump;
            rigidbody.AddForce(new Vector2(0, Mathf.Min(jump, jumpForce)), ForceMode2D.Impulse);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "PickUp" && Input.GetAxis("Jump") != 0) {
            inventory.AddItem(other.gameObject);
        }
    }
}
