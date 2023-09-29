using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoolVariable", menuName = "PragmaTechs/SO/Variables/BoolVAriable", order = 1)]
public class BoolVariable : ScriptableObject
{
    public bool Value;

    public void SetBoolean(bool value)
    {
        Value = value;
    }
}
