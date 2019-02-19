using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    Animator animator;
    private Vector2 input = new Vector2(0, 0);
    private Rigidbody2D rb;
    private bool playerExists = false;
    

 


    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (!playerExists)
        {
            DontDestroyOnLoad(GameObject.Find("Player"));
            playerExists = true;
        }
        else
        {
            Destroy(this.gameObject);
            
        }
       

    }

    // Update is called once per frame
    void Update()
    {
        // velocity == real life gravitace
        input = rb.velocity;   //.y = -1 * speed;
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("MovRight", 2);
            input.x = speed;
        }
        else if (Input.GetKey(KeyCode.D) == false)
        {
            animator.SetFloat("MovRight", 0);
            
        }

        if (Input.GetKey(KeyCode.A))
        {
            input.x = -speed;
            animator.SetFloat("MovLeft", 2);
        }
        else if (Input.GetKey(KeyCode.A) == false)
        {
            animator.SetFloat("MovLeft", 0);
       
        }

        if (Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        {
            input.y = speed;
            animator.SetFloat("MovUP", 2);
        }
        else if (Input.GetKey(KeyCode.W) == false)
        {
            animator.SetFloat("MovUP", 0);

        }
        else if (Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.A) == true)
        {
            input.y = speed;
            animator.SetFloat("MovUP", 0);
            animator.SetFloat("MovLeft", 2);
           
        }
        else if (Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.D) == true)
        {
            input.y = speed;
            animator.SetFloat("MovUP", 0);
            animator.SetFloat("MovRight", 2);
        }



        if (Input.GetKey(KeyCode.S) == true && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        {
            input.y = -speed;
            animator.SetFloat("MovDown", 2);

        }
        else if (Input.GetKey(KeyCode.S) == false)
        {
            animator.SetFloat("MovDown", 0);
      
        }
        else if (Input.GetKey(KeyCode.S) == true && Input.GetKey(KeyCode.A) == true)
        {
            input.y = -speed;
            animator.SetFloat("MovDown", 0);
            animator.SetFloat("MovLeft", 2);
            animator.SetFloat("MovRight", 2);

        }
        else if (Input.GetKey(KeyCode.S) == true && Input.GetKey(KeyCode.D) == true)
        {
            input.y = -speed;
            animator.SetFloat("MovRight", 2);
            animator.SetFloat("MovDown", 0);
            animator.SetFloat("MovLeft", 0);
        }



        rb.velocity = input;        // objekt bde rizen gravitaci
    }

   


}
