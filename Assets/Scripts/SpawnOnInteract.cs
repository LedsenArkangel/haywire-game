using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnInteract : MonoBehaviour
{
    public GameObject item;
    public string requiredItemName = "";
    string tag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if (requiredItemName == "" || Inventory.GetSelectedItemName() == requiredItemName) {
            tag = other.tag;
            Invoke("SpawnItem", 1.0F);
        }
    }

    void SpawnItem()
    {
        if (tag == "Player" && Input.GetAxis("Jump") != 0) {
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }
}
