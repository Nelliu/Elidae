using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(".");
        if (Input.GetKeyDown(KeyCode.R) == true && collision.tag == "Player")
        {
            Debug.Log("Worsssssssssssssssssssssssssssssssssssssks");
        }
    }
}
