using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    public Transform thunder;
    public GameObject thunderPrefab;
    public float thunderRate = 2.2f;
    float nextThunder = 0f;
     public GameObject mao;
    public Transform libras;
    float timer = 3f;
    float timeTrue = 1f;
     int damage = 50;
public GameObject saida;
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
    
    void Update()
    {
    
    if(Time.time >= nextThunder)
    {
      if(Input.GetButtonDown("Fire1"))  
      {
        Libras();
        nextThunder = Time.time + thunderRate;
        timeTrue += 1f;
      }
    }
     if(timeTrue >= 2f)
        {
            timer -= Time.deltaTime;

        }

    if(timer <= 0f)
    {
        Shoot();
        timer = 2.8f;
        timeTrue -= 1f;

    }
    }
     void Shoot()
    {
       RaycastHit2D hitInfo = Physics2D.Raycast(thunder.position, thunder.right);

       if(hitInfo)
       {
        TomScript enemy = hitInfo.transform.GetComponent<TomScript>();
        Instantiate(thunderPrefab, hitInfo.point, Quaternion.identity);

            if(enemy != null)
            {
                enemy.takeDamage(damage);
            }
       }



    }
    void Libras()
    {
        Instantiate(mao, libras.position, libras.rotation);
    }
}
