using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapCameraToRoom : MonoBehaviour
{
    public string messageOnFirstEnter = "";
    public AudioSource world;
    bool hasEntered = false;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            if (audio != null) {
                audio.Play();
            }
            if (world != null) {
                world.Stop();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            if (audio != null) {
                audio.Stop();
            }
            if (world != null) {
                world.Play();
            }
        }
    }

    // Called when something enters into collision
    void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -100);
            if (!hasEntered && messageOnFirstEnter != "") {
                hasEntered = true;
                Fungus.Flowchart.BroadcastFungusMessage(messageOnFirstEnter);
            }
        }
    }
}
