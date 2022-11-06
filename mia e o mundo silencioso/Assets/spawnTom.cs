using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTom : MonoBehaviour
{
    public Transform TomSpawn;
     public GameObject Tom;
    public int health = 100;
    public Animator animation;
    bool TheDamage = false;
   
    void Update()
    {
        animation.SetBool("Damage",(TheDamage));

        if(Input.GetButtonDown("Fire2"))
        {
            Spawn();
        }
    }
    void Spawn()
    {
        Instantiate(Tom, TomSpawn.position, TomSpawn.rotation);
    }


   public void takeDamage(int damage)
   {
    health -= damage;
    animation.SetBool("Damage",true);

    if(health <= 0)
    {
        Destroy(gameObject);
    }
   }
    public void FixedUpdate() {
        {
            
        }
    }
}
