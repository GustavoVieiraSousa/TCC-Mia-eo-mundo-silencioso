using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
   private static musicPlayer mp;
    void Awake()
    {
        if(mp == null){
            mp = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
