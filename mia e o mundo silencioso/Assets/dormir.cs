using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dormir : MonoBehaviour
{
 public GameObject dormindo;
 public GameObject branco;
 
    IEnumerator showDialog()
    {
         yield return new WaitForSeconds(1f);
         SceneManager.LoadScene("demo"); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
         dormindo.SetActive(true);
         StartCoroutine(showDialog());
           
        }
    }
}
