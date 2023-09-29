using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    public Button[] buttonArray;
    public GameObject[] IceArray;
    public IntVariable unlockButton;
    // Start is called before the first frame update

    private void OnEnable()
    {
        unlockButton.Value = PlayerPrefs.GetInt("unlockButton", 1);
        DisableAllButtons();
        EnableUnlockButtons();
    }

    private void DisableAllButtons()
    {
        for (int i = 0; i < buttonArray.Length; i++)
        {
            if (i + 2 > unlockButton.Value)
            {
                buttonArray[i].interactable = false;
            }
        }
    }

    private void EnableUnlockButtons()
    {
        for (int i = 2; i <= unlockButton.Value; i++)
        {
            if (i <= unlockButton.Value)
            { 
                var index = i - 2;
            IceArray[index].SetActive(false);
                buttonArray[index].interactable = true;
            }
        }
    }
    void Start()
    {

       

      
    }

    void Update()
    {
   
        
    }
    
}
