using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGate5 : MonoBehaviour
{
    public BoolVariable destroyGateBool5;
    // Start is called before the first frame update
    void Start()
    {
        destroyGateBool5.Value = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyGateBool5.Value == true)
        {
            Destroy(gameObject);
        }
    }
}
