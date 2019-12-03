using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInteraction : MonoBehaviour
{
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if(collision.collider.tag == "DownOnly") {
            collision.collider.isTrigger = true;
        }
    }
}
