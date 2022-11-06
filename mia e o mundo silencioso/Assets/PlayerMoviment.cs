using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMoviment : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float HorizontalMove = 0f;
    float Runspeed = 40f;
    bool jump = false;
    bool crouch = false;
    float Walkspeed = 2;
    void Update()
    {
      animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));
     HorizontalMove = Input.GetAxisRaw("Horizontal") * Runspeed;
     
     if(Input.GetButtonUp("slow"))
     {
      Runspeed = 40f;
     }
     if(Input.GetButtonDown("slow"))
     {
      Runspeed = 20f;
      animator.SetFloat("Speed",Runspeed);
      animator.SetFloat("Walk", Walkspeed);
     }
     if(Input.GetButtonDown("Jump"))
     {
        jump = true;
        animator.SetBool("isJump",true);
     }
     if(Input.GetButtonDown("Crouch"))
     {
        crouch = true;
     }
     else if(Input.GetButtonUp("Crouch"))
     {
        crouch = false;
     }
     if(Input.GetButtonDown("Fire2"))
     {
      Application.Quit();
     }

    }
   public void OnLanding()
    {
      animator.SetBool("isJump", false);

    }

    void FixedUpdate(){

        controller.Move(HorizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    
    }
}
