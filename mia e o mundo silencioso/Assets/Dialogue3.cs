using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue3 : MonoBehaviour
{

public string[] dialogueNPC;
public int dialogueIndex;
public GameObject dialoguePanel;
public GameObject saida;
public Text dialogueText;
public Text NameNPC;
public Image imageNPC;
public Sprite spriteNPC;
public Sprite spriteMia;
private int count;
public bool mf;
public Sprite spritelibras;
public GameObject branco;
public GameObject mao;
public Transform libras;

public bool readyToSpeak;
public bool startDialogue;

void Start() 
{
   dialoguePanel.SetActive(false); 
}

void Update()
{
    if(Input.GetButtonDown("Fire1") && readyToSpeak)
    {
        if(!startDialogue)
        {
            FindObjectOfType<playerMovimentFeira>().velocidade2 = 0f;
            StartDialogue();
        } 
    }
    if(Input.GetButtonDown("Fire1"))
    {
         if(dialogueText.text == dialogueNPC[dialogueIndex])
        {
            nextDialog();
        }
    }
}
 private void Awake() 
     {
        branco.SetActive(true);
        StartCoroutine(telaBranca());
    }
    IEnumerator telaBranca()
    {
        yield return new WaitForSeconds(1f);
        branco.SetActive(false);
    }

void nextDialog()
{
    dialogueIndex++;
    count++;

    if(dialogueIndex < dialogueNPC.Length)
    {
        StartCoroutine(showDialog());
    }
    else
    {
        dialoguePanel.SetActive(false);
        startDialogue =false;
        dialogueIndex = 0;
        FindObjectOfType<playerMovimentFeira>().velocidade2 = 2f;
        count = 1;
        saida.SetActive(true);
        Libras();
    }
}
void StartDialogue()
{
    
    count = 1;
   
    startDialogue = true;
    dialogueIndex = 0;
    dialoguePanel.SetActive(true);
    StartCoroutine(showDialog());


    
}

public void FixedUpdate() {
    
    switch(dialogueIndex)
    {
        case 0:
        NameNPC.text = "Mia";
        imageNPC.sprite = spriteMia;
        break;
       
    
       case 1:
        NameNPC.text = "Vô";
        imageNPC.sprite = spriteNPC;
       break;

       case 2:
       NameNPC.text = "Mia";
       imageNPC.sprite = spriteMia;
       break;

       case 3:
       NameNPC.text = "Vô";
       imageNPC.sprite = spriteNPC;
       break;

        case 4:
        NameNPC.text = "Mia";
        imageNPC.sprite = spriteMia;
        break;

        case 5:
       NameNPC.text = "Vô";
       imageNPC.sprite = spriteNPC;
       break;

         case 6:
        NameNPC.text = "Mia";
        imageNPC.sprite = spriteMia;
        break;

        case 7:
       NameNPC.text = "Vô";
       imageNPC.sprite = spriteNPC;
       break;

        case 8:
        NameNPC.text = "Mia";
        imageNPC.sprite = spriteMia;
        break;

         case 9:
       NameNPC.text = "Vô";
       imageNPC.sprite = spriteNPC;
       break;

       case 10:
        NameNPC.text = "Mia";
        imageNPC.sprite = spriteMia;
        break;

         case 11:
       NameNPC.text = "Vô";
       imageNPC.sprite = spriteNPC;
       break;

        case 12:
       NameNPC.text = "Vô";
       imageNPC.sprite = spriteNPC;
       break;

        case 13:
        NameNPC.text = "Mia";
        imageNPC.sprite = spriteMia;
        break;

         case 14:
       NameNPC.text = "Vô";
       imageNPC.sprite = spriteNPC;
       break;

        case 15:
       NameNPC.text = "Vô";
       imageNPC.sprite = spriteNPC;
       break;

        case 16:
        NameNPC.text = "Mia";
        imageNPC.sprite = spriteMia;
        break;

        case 17:
       NameNPC.text = "Vô";
       imageNPC.sprite = spriteNPC;
       break;

       case 18:
       NameNPC.text = "Vô";
       imageNPC.sprite = spriteNPC;
       break;

       case 19:
        NameNPC.text = "Mia";
        imageNPC.sprite = spriteMia;
        break;




    }
}

IEnumerator showDialog()
{
    dialogueText.text = "";
    foreach(char letter in dialogueNPC[dialogueIndex])
    {
        dialogueText.text += letter;
        yield return new WaitForSeconds(0.03f);
    }
}

private void OnTriggerEnter2D(Collider2D collision) 
{
    if(collision.CompareTag("mia"))
    {
        readyToSpeak = true;
    }
}
 private void OnTriggerExit2D(Collider2D collision) 
 {
    if(collision.CompareTag("mia"))
    {
        readyToSpeak = false;
    }
 }
  void Libras()
    {
        Instantiate(mao, libras.position, libras.rotation);
    }
}
    
   

