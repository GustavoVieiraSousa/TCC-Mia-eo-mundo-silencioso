using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovimentFeira : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    private float velocidade =0;
    public  float velocidade2 = 3;
    private Vector2 direcao;
    public float Walkspeed = 2;
    private bool m_FacingRight = true;
    public Transform entrada;
    float rangeDoor = 0.5f;
    public LayerMask PlayerLayer;
   

    
    void Update()
    {
        velocidade = 0;
         animator.SetFloat("Speed", Mathf.Abs(velocidade));


          InputPersonagem();
        transform.Translate(direcao * velocidade * Time.deltaTime);

    }

     void InputPersonagem()
     {
        velocidade = velocidade + velocidade2;
        direcao = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            velocidade2 = 3;
            animator.SetFloat("Speed",velocidade);
            animator.SetFloat("Walk", Walkspeed);
            direcao += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
           
            direcao += Vector2.right;
            velocidade2 = 3;
            animator.SetFloat("Speed",velocidade);
            animator.SetFloat("Walk", Walkspeed);
        }
         if (Input.GetKey(KeyCode.RightArrow) && !m_FacingRight)
        {
            Flop();
        }

       if (Input.GetKey(KeyCode.LeftArrow) && m_FacingRight)
        {
            Flop();
        }

}
  public void FixedUp(){

    velocidade = 0;
  }
  
  private void Flop()
	{
		
		m_FacingRight = !m_FacingRight;

		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

      void entrar()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(entrada.position, rangeDoor, PlayerLayer);

        foreach(Collider2D player in hitPlayer)
        {
          SceneManager.LoadScene("demo");  
        }
    }
}
