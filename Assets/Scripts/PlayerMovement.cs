using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public GameObject panel;
    public float speed;
    public float jumpspeed;
    bool jump = false;
    bool crouch = false;
    float horizontalMovement;
    float verticalMovement;
    SpriteRenderer spriteRenderer;
    Vector3 movement;
    Rigidbody2D rb;

    public static List<string> pickies;
    int collision_count;
      
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pickies = new List<string>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
               
    }


     void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal")*speed ;
        verticalMovement = Input.GetAxis("Vertical")*jumpspeed ;

        movement = new Vector3(horizontalMovement, verticalMovement,0);

        
        transform.position += movement * Time.deltaTime;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        if (Input.GetAxis("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            jump = true;
            animator.SetBool("IsJump", jump);
        }
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsThrow", true);

        }
        else if (Input.GetButtonUp("Jump"))
        {
            animator.SetBool("IsThrow", false);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            panel.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            panel.SetActive(false);
        }


    }
    public void OnLanding()
    {
        jump = false;
        animator.SetBool("IsJump", jump);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PickUp"))
        {
            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
            collision_count++;
            pickies.Add(collision.name);
            Debug.Log("Items: " + pickies);
          
        }

    }


}
