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

    public float speed = 7;
    public float jump = 100;
    public float minJump = 10;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
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
    }

    // Update is called at constant rate independent of frame rate
    void FixedUpdate()
    {
        // Horizontal movement
        var horizontalSpeed = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.position += new Vector3(horizontalSpeed, 0, 0);

        // Jump
        if (Input.GetAxis("Vertical") > 0 && !animator.GetBool("isJumping") && !animator.GetBool("isFalling")) {
            var jumpForce = Input.GetAxis("Vertical") * jump * minJump;
            rigidbody.AddForce(new Vector2(0, Mathf.Min(jump, jumpForce)), ForceMode2D.Impulse);
        }

        var verticalSpeed = rigidbody.velocity.y;
        // Set animation
        if (verticalSpeed > 0) {
            // Jumping
            animator.SetBool("isIdle", false);
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("isFalling", false);
        } else if (verticalSpeed < 0) {
            // Falling
            animator.SetBool("isIdle", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
            animator.SetBool("isRunning", false);
        } else {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
            if (Input.GetAxis("Horizontal") != 0) {
                // Running 
                animator.SetBool("isIdle", false);
                animator.SetBool("isRunning", true);
            } else {
                // Idle
                animator.SetBool("isIdle", true);
                animator.SetBool("isRunning", false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.tag == "DownOnly" && rigidbody.velocity.y >= 0) {
            collision.collider.isTrigger = true;
        }
    } 

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "DownOnly" && rigidbody.velocity.y < 0) {
            other.isTrigger = false;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
            if (Input.GetAxis("Horizontal") != 0) {
                // Running 
                animator.SetBool("isIdle", false);
                animator.SetBool("isRunning", true);
            } else {
                // Idle
                animator.SetBool("isIdle", true);
                animator.SetBool("isRunning", false);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if(collision.collider.tag == "DownOnly") {
            collision.collider.isTrigger = true;
        }
    }
}
