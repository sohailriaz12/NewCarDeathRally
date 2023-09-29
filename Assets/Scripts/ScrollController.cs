using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    //public Transform pos;
    public IntVariable increasePos;
   
   
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("increasePos", increasePos.Value);
       
        
    }

    // Update is called once per frame
    void Update()
    {
      
       
        
            

        
           
    }

    public void unlockAddPosition()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y + increasePos.Value, transform.position.z);
    }
}
