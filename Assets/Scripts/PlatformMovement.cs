using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    //adjust this to change speed
    public float speed = 0.05f;
    //adjust this to change how high it goes
    bool collided = false;
    public Transform target;

    public void Update()
    {
        Vector2 target_y = new Vector2(transform.position.x, target.position.y);
        if (collided == true)
        { 
        Vector2 pos = gameObject.transform.position;
        //calculate what the new Y position will be
        float newY = Time.deltaTime * speed;
        //set the object's Y to the new calculated Y
        gameObject.transform.position = Vector2.MoveTowards(pos, target_y, newY);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided " + collision.gameObject.name);
            //get the objects current position and put it in a variable so we can access it later with less code

            collided = true;



        }
    }
}
