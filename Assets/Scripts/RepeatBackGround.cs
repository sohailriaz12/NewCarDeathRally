using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    public BoolVariable makeSpeedZero;
    private Vector3 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        makeSpeedZero.Value = false;
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > StartPos.z + 35)
        {
            transform.position = StartPos;
        }

        if(makeSpeedZero.Value== true)
        {
             MoveForward moveForwardScript = GetComponent<MoveForward>();
                moveForwardScript.moveForwardSpeed = 0f;
        }
    }
}
