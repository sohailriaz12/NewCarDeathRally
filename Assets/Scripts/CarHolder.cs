using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarHolder : MonoBehaviour
{
    
   public int currentCar = 0;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button PrevButton;
    [SerializeField] private Button proceed;
    private GameObject[] carsPrefab;
  
   

    private void Awake()
    {
        selectCar(0);
    }

    private void Start()
    {
     
        
    }



    private void selectCar(int _index)
    {
        PrevButton.interactable = (_index != 0);
        nextButton.interactable = (_index != transform.childCount - 1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }

    public void changeCar(int _change)
    {
        currentCar += _change;
        selectCar(currentCar);
    }

    public void startGameWithSelectedPlayer()
    {
        PlayerPrefs.SetInt("selectedCharacter", currentCar);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }


}




