﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOrder : MonoBehaviour
{                   
    
    
    // logic for npc ORDER IN LAYER, -> if player is before or behind npc (normal sized npc only)

    public GameObject NpcObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            NpcObject.GetComponent<SpriteRenderer>().sortingOrder = 6;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            NpcObject.GetComponent<SpriteRenderer>().sortingOrder = 4;
        }
    }
}
