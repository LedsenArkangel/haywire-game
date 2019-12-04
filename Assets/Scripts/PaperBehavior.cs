using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperBehavior : MonoBehaviour
{
    public List<GameObject> pieces;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(gameObject);
        }
    }
}
