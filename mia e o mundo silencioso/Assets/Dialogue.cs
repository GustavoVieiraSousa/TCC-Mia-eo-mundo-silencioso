using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

public string[] dialogueNPC;
public int dialogueIndex;
public GameObject dialoguePanel;
public GameObject casa;
public Text dialogueText;
public Text NameNPC;
public Image imageNPC;
public Sprite spriteNPC;
public Sprite spriteMia;
private int count;
public bool mf;
public GameObject branco;

public bool readyToSpeak;
public bool startDialogue;

void Start() 
{
   dialoguePanel.SetActive(false); 
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

void Update()
{
    if(Input.GetButtonDown("Fire1") && readyToSpeak)
    {
        if(!startDialogue)
        {
            FindObjectOfType<PlayerMoviment3d>().velocidade2 = 0f;
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
        FindObjectOfType<PlayerMoviment3d>().velocidade2 = 3f;
        count = 1;
        casa.SetActive(true);
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
       NameNPC.text = "Vô";
       imageNPC.sprite = spriteNPC;
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
    if(collision.CompareTag("Player"))
    {
        readyToSpeak = true;
    }
}
 private void OnTriggerExit2D(Collider2D collision) 
 {
    if(collision.CompareTag("Player"))
    {
        readyToSpeak = false;
    }
 }
}
    
   

