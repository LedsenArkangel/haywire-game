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

    public float speed = 7;
    public float jump = 100;
    public float minJump = 10;
    public Fungus.Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!flowchart.GetBooleanVariable("isPaused")) {
            if (Input.GetAxis("Horizontal") < 0) {
                // left
                spriteRenderer.flipX = true;
            } else if (Input.GetAxis("Horizontal") > 0) {
                // right
                spriteRenderer.flipX = false;
            }

            if (Input.GetAxis("Jump") != 0 && !animator.GetBool("isClimbing")) {
                // interact
                StartCoroutine(PlayInteracting());
            }
        }
    }

    // Update is called at constant rate independent of frame rate
    void FixedUpdate()
    {
        if (!flowchart.GetBooleanVariable("isPaused")) {
            if (animator.GetBool("isClimbing")) {
                // Climb
                if (Input.GetAxis("Horizontal") != 0) {
                    // Jump out
                    animator.SetFloat("climbingSpeed", 1.0F);
                    animator.SetBool("isClimbing", false);
                    rigidbody.gravityScale = 1;
                }
                
                if (Input.GetAxis("Vertical") != 0) {
                    var verticalSpeed = Input.GetAxis("Vertical") * speed * Time.deltaTime;
                    transform.position += new Vector3(0, verticalSpeed, 0);
                    animator.SetFloat("climbingSpeed", 1.0F);
                } else {
                    animator.SetFloat("climbingSpeed", 0.0F);
                }
                
            } else {
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
        }
    }

    IEnumerator PlayInteracting()
    {
        animator.Play("interacting");
        
        yield return new WaitForSeconds(1);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.name == "DropDown") {
            Physics2D.IgnoreCollision(collider, collision.collider);
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (!flowchart.GetBooleanVariable("isPaused")) {
            if (other.tag == "Ladder" && Input.GetAxis("Vertical") != 0) {
                animator.SetBool("isClimbing", true);
                // Snap to ladder
                transform.position = new Vector2(other.gameObject.transform.position.x, transform.position.y);
                // Stop gravity
                rigidbody.velocity = new Vector2(0, 0);
                rigidbody.gravityScale = 0;
                // Use climbing animation
                animator.Play("climbing");
                animator.SetFloat("climbingSpeed", 1.0F);
            }
        }
    }
}
