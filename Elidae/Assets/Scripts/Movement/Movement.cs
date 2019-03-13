using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    Animator animator;
    private Vector2 input = new Vector2(0, 0);
    private Rigidbody2D rb;
    private static bool playerExists;
    public static bool MovementDisabled;
    public GameObject CanvasGUI;
    
    
 


    // Use this for initialization
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (!playerExists)
        {
            DontDestroyOnLoad(CanvasGUI);
            DontDestroyOnLoad(gameObject);
            playerExists = true;
        }
        else
        {
            Destroy(gameObject);
            
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (MovementDisabled == false)
        {
            CheckMovement();
            rb.velocity = input;
        }
        else
        {
            animator.SetFloat("MoveUp", 0);
            animator.SetFloat("MoveDown", 0);
            animator.SetFloat("MoveLeft", 0);
            animator.SetFloat("MoveRight", 0);
        }
        

        
        
    }

   
    private void CheckMovement()
    {
        // velocity == real life gravitace
        input = rb.velocity;   //.y = -1 * speed;
        if (Input.GetKey(KeyCode.D) == true && Input.GetKey(KeyCode.A) == false)
        {
            animator.SetFloat("MoveRight", 2);
            
            input.x = speed;
        }
        else if (Input.GetKey(KeyCode.D) == false)
        {
            animator.SetFloat("MoveRight", 0);

        }
        else if (Input.GetKey(KeyCode.D) == true && Input.GetKey(KeyCode.A) == true)
        {
            animator.SetFloat("MoveRight", 0);

        }

        if (Input.GetKey(KeyCode.A) == true && Input.GetKey(KeyCode.D) == false)
        {
            input.x = -speed;
           
            animator.SetFloat("MoveLeft", 2);
        }
        else if (Input.GetKey(KeyCode.A) == false)
        {

            animator.SetFloat("MoveLeft", 0);
        }
        else if (Input.GetKey(KeyCode.A) == true && Input.GetKey(KeyCode.D) == true)
        {

            animator.SetFloat("MoveLeft", 0);
        }

        if (Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        {
            input.y = speed;
         
            animator.SetFloat("MoveUp", 2);
        }
        else if (Input.GetKey(KeyCode.W) == false)
        {
    
            animator.SetFloat("MoveUp", 0);

        }
        else if (Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.A) == true && Input.GetKey(KeyCode.D) == false)
        {
            input.y = speed;
           animator.SetFloat("MoveUp", 0);
           animator.SetFloat("MoveLeft", 2);
    

        }
        else if (Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.D) == true && Input.GetKey(KeyCode.A) == false)
        {
            input.y = speed;
            animator.SetFloat("MoveUp", 0);
            animator.SetFloat("MoveRight", 2);
        }
        else if (Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.D) == true && Input.GetKey(KeyCode.A) == true)
        {
            animator.SetFloat("MoveUp", 0);
        }




        if (Input.GetKey(KeyCode.S) == true && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        {
            input.y = -speed;
            animator.SetFloat("MoveDown", 2);
           

        }
        else if (Input.GetKey(KeyCode.S) == false)
        {
            animator.SetFloat("MoveDown", 0);


        }
        else if (Input.GetKey(KeyCode.S) == true && Input.GetKey(KeyCode.A) == true && Input.GetKey(KeyCode.D) == false)
        {
            input.y = -speed;
            animator.SetFloat("MoveDown", 0);
            animator.SetFloat("MoveLeft", 2);


        }
        else if (Input.GetKey(KeyCode.S) == true && Input.GetKey(KeyCode.D) == true && Input.GetKey(KeyCode.A) == false)
        {
            input.y = -speed;
            animator.SetFloat("MoveRight", 2);
            animator.SetFloat("MoveDown", 0);
            animator.SetFloat("MoveLeft", 0);
          
        }
        else if (Input.GetKey(KeyCode.S) == true && Input.GetKey(KeyCode.D) == true && Input.GetKey(KeyCode.A) == true)
        {
            animator.SetFloat("MoveDown", 0);
        }



     
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mouseStartPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            Debug.Log(mouseStartPos.x);
            Debug.Log(mouseStartPos.y);

            transform.position = mouseStartPos;
            //transform.position = pz;

        }
    }


   
   
}
