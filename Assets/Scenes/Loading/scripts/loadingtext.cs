using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingtext : MonoBehaviour {

    private RectTransform rectComponent;
    private Image imageComp;

   private float speed = 0.2f;
    public Text text;
    public Text textNormal;


    // Use this for initialization
    void Start () {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        imageComp.fillAmount = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        int a = 0;
        if (imageComp.fillAmount != 1f)
        {
            imageComp.fillAmount = imageComp.fillAmount + Time.deltaTime * speed;
            a = (int)(imageComp.fillAmount * 100);
            if (a > 0 && a <= 50)
            {
                textNormal.text = "Loading...";
            }
           
            else if (a > 50 && a < 100)
            {
                textNormal.text = "Please wait...";
            }
            else if (a==100)
            {
                speed = 0;
                SceneManager.LoadScene("LevelSelection");

            }
            text.text = a + "%";
        }

    }
}
