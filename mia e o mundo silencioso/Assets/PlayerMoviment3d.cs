using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoviment3d : MonoBehaviour
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
    public GameObject saida;
    public AudioClip sons_passos;
   private AudioSource audioP;

     void Start() {
        animator = gameObject.GetComponent<Animator>();
        audioP = gameObject.GetComponent<AudioSource>();
        audioP.clip = sons_passos;
        audioP.Play();
    }
    
    void Update()
    {
        velocidade = 0;
         animator.SetFloat("Speed", Mathf.Abs(velocidade));
       

          InputPersonagem();
        transform.Translate(direcao * velocidade * Time.deltaTime);
        InputSound();

        if(Input.GetButtonDown("Fire2"))
        {
            entrar();
        }
    }

     void InputPersonagem()
     {
        velocidade = velocidade + velocidade2;
        direcao = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
             
             velocidade2 = 3;
            animator.SetFloat("Speed",velocidade);
            animator.SetFloat("Walk", Walkspeed);
            direcao += Vector2.up;
            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
             velocidade2 = 3;
            animator.SetFloat("Speed",velocidade);
            animator.SetFloat("Walk", Walkspeed);
            direcao += Vector2.down;
        }
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
    
    IEnumerator showDialog()
    {
         yield return new WaitForSeconds(2f);
         SceneManager.LoadScene("feira"); 
    }
    void entrar()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(entrada.position, rangeDoor, PlayerLayer);

        foreach(Collider2D player in hitPlayer)
        {
          saida.SetActive(true);
         StartCoroutine(showDialog());
        }
    }
    void InputSound()
     {
       

        if (Input.GetKey(KeyCode.UpArrow))
        {
              audioP.clip = sons_passos;
        audioP.Play();
             
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
             audioP.clip = sons_passos;
        audioP.Play(); 
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            audioP.clip = sons_passos;
        audioP.Play(); 
            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            audioP.clip = sons_passos;
        audioP.Play();
           
        }
     }
}
