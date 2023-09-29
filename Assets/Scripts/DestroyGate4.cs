using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGate4 : MonoBehaviour
{
    public BoolVariable destroyGateBool4;
    // Start is called before the first frame update
    void Start()
    {
        destroyGateBool4.Value = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyGateBool4.Value == true)
        {
            Destroy(gameObject);
        }
    }
}
