using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attention : MonoBehaviour
{
    public GameObject target;
    private IAstarAI destinationTarget;
 

    // Start is called before the first frame update
    void Start()
    {
        destinationTarget = gameObject.GetComponent<IAstarAI>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            target.transform.position = collision.transform.position;       


        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            target.transform.position = collision.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            target.transform.position = collision.transform.position;
        }
       

  

    }

}
