using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGate3 : MonoBehaviour
{
    public BoolVariable destroyGateBool3;
    // Start is called before the first frame update
    void Start()
    {
        destroyGateBool3.Value = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (destroyGateBool3.Value == true)
        {
            Destroy(gameObject);
        }
    }
}
