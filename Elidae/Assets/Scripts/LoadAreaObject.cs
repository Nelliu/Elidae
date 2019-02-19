using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAreaObject : MonoBehaviour
{
    public static string ToArea;

    // Start is called before the first frame update
    void Start()
    {
        
        if(ToArea == gameObject.name)
        {
            GameObject.Find("Player").transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
