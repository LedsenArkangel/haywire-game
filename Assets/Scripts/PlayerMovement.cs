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
    public GameObject right_wall;
    public float speed;
    public float jumpSpeed;
    bool jump = false;
    bool crouch = false;
    SpriteRenderer spriteRenderer;
    Vector3 movement;
    Rigidbody2D rigidbody2d;

    public Texture2D bat;
    public RawImage bat_raw;
    public static List<string> pickies;
    int collision_count;

    string source_bat;
      
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        pickies = new List<string>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        // string bat_name= (PlayerPrefs.GetString("Bat", source_bat));
        // bat_raw.texture = Resources.Load<Texture2D>(bat_name);
    }


     void FixedUpdate()
    {
        // Horizontal movement
        float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.position += new Vector3(horizontalMovement, 0, 0);
        // Running animation
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        // Flip sprite with horizontal movement
        if (Input.GetAxis("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Jump
        if (Input.GetAxis("Vertical") > 0 && !jump)
        {
            rigidbody2d.velocity = new Vector2(0.5f * horizontalMovement, jumpSpeed);
            jump = true;
            animator.SetBool("IsJump", jump);
        }

        // Landing
        if (rigidbody2d.velocity.y == 0) {
            jump = false;
            animator.SetBool("IsJump", jump);
        }

        // Set animation for throw
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsThrow", true);
            if (pickies.Count > 0)
            {
                //throw
                Debug.Log("Items: " + pickies);
                Instantiate(Resources.Load<GameObject>("/Prefab/" + pickies[0]), transform.position + new Vector3(20, 0, 0), Quaternion.identity);
            }
        }
        else if (Input.GetButtonUp("Jump"))
        {
            animator.SetBool("IsThrow", false);
        }
      
        if (source_bat == "bat")
        {
            Vector2 up = new Vector2(50, 0);
            right_wall.transform.Translate(up * 10 * Time.deltaTime);
            source_bat = "none";
        }

        // Inventory
        if (Input.GetKeyDown(KeyCode.Q))
        {
            panel.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            panel.SetActive(false);
        }
       


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Pick up item on collision
        if(collision.gameObject.CompareTag("PickUp"))
        {
            pickies.Add(collision.name);
            Destroy(collision.gameObject);
            Debug.Log("Items: " + pickies);
        }
    }

}
