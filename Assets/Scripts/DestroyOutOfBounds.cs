using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
   
    private float upperBound = -5f;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        

         if(transform.position.z < upperBound)
        {
            Destroy(gameObject);
        }
    }
   
}
