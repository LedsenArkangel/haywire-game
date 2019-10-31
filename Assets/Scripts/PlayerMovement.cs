using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Fungus;

public class PlayerMovement : MonoBehaviour
{
    public bool PlayerMove;
    public CharacterController2D controller;
    public Flowchart flowchart;
    public Animator animator;
    public GameObject panel;
    public GameObject right_wall;
    public float speed;
    public float jumpspeed = 6.0f;
    bool jump = false;
    bool crouch = false;
    float horizontalMovement;
    float verticalMovement;
    SpriteRenderer spriteRenderer;
    Vector3 movement;
    Rigidbody2D rb;

    public Texture2D bat;
    public RawImage bat_raw;
    public static List<string> pickies;
    int collision_count = 0;

    string source_bat;
      
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
        string bat_name= (PlayerPrefs.GetString("Bat", source_bat));
        bat_raw.texture = Resources.Load<Texture2D>(bat_name);
    }


     void FixedUpdate()
    {
        if (PlayerMove)
        {

            horizontalMovement = Input.GetAxis("Horizontal") * speed;
            verticalMovement = Input.GetAxis("Vertical") * jumpspeed;

            movement = new Vector3(horizontalMovement, verticalMovement, 0);


            transform.position += movement * Time.deltaTime;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));


            if (source_bat == "bat")
            {
                Vector2 up = new Vector2(50, 0);
                right_wall.transform.Translate(up * 10 * Time.deltaTime);
                source_bat = "none";
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                spriteRenderer.flipX = false;
            }
            if (Input.GetAxis("Vertical") > 0)
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
        
    }
    public void OnLanding()
    {
        jump = false;
        animator.SetBool("IsJump", jump);

    }

    public void OnSomething()
    {
        if(PlayerMove)
        {
            PlayerMove = false;
        } else
        {
            PlayerMove = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PickUp"))
        {
            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
            collision_count++;
            Debug.Log(collision_count);
            if (collision_count == 1)
            {
                flowchart.SendFungusMessage("bat");
                Debug.Log("here");
            }
            if (collision_count == 2)
            {
                flowchart.SendFungusMessage("scissors");
            }
            pickies.Add(collision.name);
            source_bat = collision.name;
            PlayerPrefs.SetString("Bat", pickies[0]);
            Debug.Log("Items: " + pickies);

          
        }
        

    }

  

}
