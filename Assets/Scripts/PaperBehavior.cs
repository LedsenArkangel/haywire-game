using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperBehavior : MonoBehaviour
{
    public List<GameObject> pieces;
    public AudioClip sfxCut;
    static bool isCut = false;
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

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player" && Input.GetAxis("Jump") != 0 && Inventory.GetSelectedItemName() == "Scissors") {
            foreach(GameObject piece in pieces) {
                Instantiate(piece, transform.position, Quaternion.identity);
            }
            if (!isCut) {
                isCut = true;
                Fungus.Flowchart.BroadcastFungusMessage("PaperCut");
            }
            audio.PlayOneShot(sfxCut);
            Destroy(gameObject);
        }
    }
}
