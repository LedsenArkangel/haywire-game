using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpBehavior : MonoBehaviour
{
    public float x;
    public float y;
    public GameObject targetObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            if (targetObj != null) {
                other.gameObject.transform.position = targetObj.transform.position;
            } else {
                other.gameObject.transform.position = new Vector2(x, y);
            }
        }
    }
}
