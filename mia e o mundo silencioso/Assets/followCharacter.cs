using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCharacter : MonoBehaviour
{
   float speed = 63f;
   public Transform Libras;

    void Start()
    {
        Libras = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Libras.position, speed * Time.deltaTime);

       
    }
}
