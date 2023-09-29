using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateProperty : MonoBehaviour
{
    [SerializeField] private int gateNo;
    public TextMeshPro gateNoText;

    public IntVariable bulletsOnCar;
   

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        gateNoText.text = "+" + gateNo;
    }

    public void gateText()
    {
       
        bulletsOnCar.Value = bulletsOnCar.Value + gateNo;
        
    }
}
