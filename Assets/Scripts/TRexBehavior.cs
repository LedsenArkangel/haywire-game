using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexBehavior : MonoBehaviour
{
    public static bool batTaken = false;
    public float speed = 5.0F;
    public GameObject drop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0.0F, 0.0F);
        if (transform.position.x > 26.12F) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Fungus.Flowchart.BroadcastFungusMessage("TRexDisappeared");
            var rndRotation = new Quaternion(0.0F, 0.0F, 0.0F, 0.0F);
            rndRotation.eulerAngles = new Vector3(0.0F, 0.0F, Random.Range(-180.0F, 180.0F));
            var obj = Instantiate(drop, transform.position, rndRotation);
            obj.name = "Baseball Bat";
            batTaken = true;
            Destroy(gameObject);
        }
    }
}
