using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRexRoomBehavior : MonoBehaviour
{
    public GameObject darkness;
    public GameObject trex;
    public Vector3 position = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && GameObject.FindWithTag("Enemy") == null && darkness == null && !TRexBehavior.batTaken) {
            Instantiate(trex, position, Quaternion.identity);
        }
    }
}
