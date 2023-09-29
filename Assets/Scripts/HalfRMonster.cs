using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfRMonster : MonoBehaviour
{
    public IntVariable monsterSpeed;
    // Start is called before the first frame update
    void Start()
    {
        monsterSpeed.Value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * monsterSpeed.Value);
    }
}
