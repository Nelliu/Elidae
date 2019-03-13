using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAreaObject : MonoBehaviour
{
    public static string ToArea;
    public static string Direction;

    // Start is called before the first frame update
    void Start()
    {
       
        if(ToArea == gameObject.name)
        {
            if(Direction == "up")
            {
                GameObject.Find("Player").transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 20);
            }
            else if (Direction == "down")
            {
                GameObject.Find("Player").transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 5);
            }
            else
            {
                GameObject.Find("Player").transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            }

        
           
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
