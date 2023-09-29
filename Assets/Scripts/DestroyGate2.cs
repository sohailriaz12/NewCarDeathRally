using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGate2 : MonoBehaviour
{
    public BoolVariable destroyGateBool2;

    // Start is called before the first frame update
    void Start()
    {
        destroyGateBool2.Value = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyGateBool2.Value == true)
        {
            Destroy(gameObject);
        }
       
    }
}
