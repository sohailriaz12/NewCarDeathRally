using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonPane : MonoBehaviour
{
    public IntVariable unlockedLevels;
    public IntVariable currentLevel;

    private void OnEnable()
    {
        if (unlockedLevels.Value == currentLevel.Value && currentLevel.Value<22)
        {
            unlockedLevels.Value += 1;
            PlayerPrefs.SetInt("unlockButton", unlockedLevels.Value);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
