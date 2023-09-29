using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameObjectReference", menuName = "PragmaTechs/SO/Variables/GameObjectReference", order = 1)]

public class GameObjectReference : ScriptableObject
{
    public GameObject Value;

    public void SetGameObject(GameObject go)
    {
        Value = go;
    }

}
