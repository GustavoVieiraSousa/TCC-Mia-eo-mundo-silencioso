using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class entraTela : MonoBehaviour

{ public GameObject saida;
    public GameObject branco;

 private void Awake() {
     branco.SetActive(true);
        StartCoroutine(telaBranca());
    }
    IEnumerator telaBranca()
    {
        yield return new WaitForSeconds(3f);
        branco.SetActive(false);
    }

    IEnumerator showDialog()
    {
         yield return new WaitForSeconds(1f);
         SceneManager.LoadScene("demo"); 
    }

    void FixedUpdate()
    {
        if(Input.GetButtonDown("Fire1"))
        {
         saida.SetActive(true);
         StartCoroutine(showDialog());
           
        }
    }
}
