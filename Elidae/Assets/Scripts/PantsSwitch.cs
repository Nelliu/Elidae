using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantsSwitch : MonoBehaviour
{
    Animator animator;

    public static bool Up;
    public static bool Down;
    public static bool Left;
    public static bool Right;



    public AnimatorControllerParameter AnimatorOver;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       
            
    }

    // Update is called once per frame
    void Update()
    {
        if (Right == true)
        {
            animator.SetBool("Right", true);
        }
        else if (Right == false)
        {
            animator.SetBool("Right", false);
        }

        if (Left == true)
        {
            animator.SetBool("Left", true);
        }
        else if (Left == false)
        {
            animator.SetBool("Left", false);
        }

        if (Up == true)
        {

            animator.SetBool("Up", true);
        }
        else if (Up == false)
        {
            animator.SetBool("Up", false);
        }

        if (Down == true)
        {
            animator.SetBool("Down", true);
        }
        else if (Down == false)
        {
            animator.SetBool("Down", false);
        }

    }
}
