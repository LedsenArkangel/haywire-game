using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PlatformMovement : MonoBehaviour
{

    //adjust this to change speed
    public float speed = 0.05f;
    //adjust this to change how high it goes
    bool collided = false;
    public Transform target;
    public Flowchart flowchart;
    Vector2 pos;
    Vector2 target_y;
    public void Start()
    {
     
    }
    public void Update()
    {
        pos = gameObject.transform.position;
        target_y = new Vector2(transform.position.x, target.position.y);
        if (collided == true)
        { 
        //calculate what the new Y position will be
        float newY = Time.deltaTime * speed;
        
        gameObject.transform.position = Vector2.MoveTowards(pos, target_y, newY);
            //set the object's Y to the new calculated Y
        }
    }
    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided " + collision.gameObject.name);
            //get the objects current position and put it in a variable so we can access it later with less code

            collided = true;
            flowchart.SetBooleanVariable("Platform", true);
            flowchart.SendFungusMessage("hi");

        }
    }
}
