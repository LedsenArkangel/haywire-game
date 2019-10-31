﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapCameraToRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when something enters into collision
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -100);
        }
    }
}
