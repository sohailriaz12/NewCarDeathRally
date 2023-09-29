using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntVariable", menuName = "PragmaTechs/SO/Variables/IntVariable", order = 1)]
public class IntVariable : ScriptableObject
{
    public int Value;

    public void DecreaseValue(int val)
    {
        Value -= val;
    }
}
