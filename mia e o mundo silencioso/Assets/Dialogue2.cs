using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue2 : MonoBehaviour
{

public string[] dialogueNPC;
public int dialogueIndex;
public GameObject dialoguePanel;
public Text dialogueText;
public Text NameNPC;
public Image imageNPC;
public Sprite spriteMPC;
public Sprite spriteNia;
private int count;
public bool mf;

public bool readyToSpeak;
public bool startDialogue;

void Start() 
{
   dialoguePanel.SetActive(false); 
}

void Update()
{
    if(readyToSpeak)
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
        if(mf = true)
        {
            Destroy(gameObject);
        }
    }
}
void StartDialogue()
{
    
    count = 1;
    NameNPC.text = "Vô";
    imageNPC.sprite = spriteMPC;
    startDialogue = true;
    dialogueIndex = 0;
    dialoguePanel.SetActive(true);
    StartCoroutine(showDialog());

    
}

public void FixedUpdate() {
    
    switch(count)
    {
       default: 
       case 1:
        NameNPC.text = "Vô";
        imageNPC.sprite = spriteMPC;
       break;

       case 2:
        NameNPC.text = "Mia";
        imageNPC.sprite = spriteNia;
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
    
   

