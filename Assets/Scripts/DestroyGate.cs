using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGate : MonoBehaviour
{
    public BoolVariable destroyGateBool;
   
    // Start is called before the first frame update
    void Start()
    {
        destroyGateBool.Value = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(destroyGateBool.Value == true)
        {
            Destroy(gameObject);
        }

       
    }
}
