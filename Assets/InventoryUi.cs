﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUi : MonoBehaviour
{
    public Transform itemsParent;
    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        for(int i=0;i<slots.Length;i++)
        {
            if (i < PlayerMovement.pickies.Count)
            {
               
            }
        }
    }
}