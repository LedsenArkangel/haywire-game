using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRandomlyOnStart : MonoBehaviour
{
    Rigidbody2D rigidbody;

    public float forceX = 10.0F;
    public float forceY = 5.0F;
    public float torque = 2.0F;
    public int destroyAfter = 5; // seconds
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(new Vector2(Random.Range(forceX * -1, forceX), Random.Range(0.0F, forceY)), ForceMode2D.Impulse);
        rigidbody.AddTorque(Random.Range(torque * -1, torque));
        if (destroyAfter > 0) {
            Destroy(gameObject, destroyAfter);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
