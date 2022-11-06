using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saidaFeira : MonoBehaviour
{
    public GameObject saida;
    public GameObject branco;

 private void Awake() {
     branco.SetActive(true);
        StartCoroutine(telaBranca());
    }
    IEnumerator telaBranca()
    {
        yield return new WaitForSeconds(1f);
        branco.SetActive(false);
    }

    IEnumerator showDialog()
    {
         yield return new WaitForSeconds(1f);
         SceneManager.LoadScene("carro"); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("mia"))
        {
         saida.SetActive(true);
         StartCoroutine(showDialog());
           
        }
    }
}
