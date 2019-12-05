using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendFungusMessage : MonoBehaviour
{
    public string message = "";
    bool hasSent = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (!hasSent && message != "" && other.tag == "Player") {
            hasSent = true;
            Fungus.Flowchart.BroadcastFungusMessage(message);
        }
    }
}
