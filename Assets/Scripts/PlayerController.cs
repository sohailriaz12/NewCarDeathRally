using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public GameObject[] CharacterPosition;
    private int Currentpositionindex = 1;
    private Animator playerAnim;

    public float xRange = 0.250f;
    

    // Unity buttons and UI

    public TextMeshProUGUI ScoreText;
    public TextMeshPro carRemainingBullets;
    public ParticleSystem gateParticle;
   
    // Audio listners and explosion particles


    // Float and Int variables

    private float distance = 0.45f;
    private float leftBoundry = 0.178f;        //0.189f;
    private float rightBoundry = -0.250f;              //-0.256f;
    public bool gameOver;
    private float score;
    private Vector2 touchStartPos;
    private Vector2 touchCurrentPos;
    private Vector2 touchEndPos;
    public float swipeRange;
    public float tapRange;
    private bool swipeIsStop = false;
   

    // Scriptable objects and Events

    public BoolVariable canNotShoot;
    public GameEvent RestartButton;
    public GameEvent gateSound;
    public GameEvent onGameLoss;
    
    public IntVariable bulletsOnCar;
    public BoolVariable playAnimation;
    public BoolVariable destroyGateBool;
    public BoolVariable destroyGateBool2;
    public BoolVariable destroyGateBool3;
    public BoolVariable destroyGateBool4;
    public BoolVariable destroyGateBool5;
    public BoolVariable playCarMovingAnim;
  
    //private Vector3 currentPosition;
    //[SerializeField] private Vector3 changePosition;
   

    

   
    void Start()
    {
        transform.position = CharacterPosition[Currentpositionindex].transform.position;
        playerAnim = GetComponent<Animator>();
        canNotShoot.Value = false;
        bulletsOnCar.Value = 100;
        gameOver = false;
        playCarMovingAnim.Value = false;
        
        
       




    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    if (currentPositionIndex < 1)
        //    {
        //        currentPositionIndex += 0;

        //        transform.position = CharacterPosition[currentPositionIndex].transform.position;
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{

        //    if (currentPositionIndex > 1)
        //    {
        //        currentPositionIndex -= 0;

        //        transform.position = CharacterPosition[currentPositionIndex].transform.position;
        //    }

       // transform.Translate(Vector3.forward * Time.deltaTime * speed);


        //}






        MovePlayerHorizontally();
         PlayerBoundry();
        
         Swipe();
        if (bulletsOnCar.Value <= 0)
        {
            canNotShoot.Value = true;
            RestartButton.Raise();
        }

        if (playAnimation.Value == true)
        {
            playerAnim.SetBool("CarEndAnimation", true);
        }

       else if (playCarMovingAnim.Value == true)
        {

            playerAnim.enabled = true;
        }
        //if (playCarMovingAnim.Value == false)
        //{
        //    playerAnim.SetBool("CarMovingAnim", false);
        //}

    }



    void PlayerBoundry()
    {
        if (transform.position.x < rightBoundry)
        {
            transform.position = new Vector3(rightBoundry, transform.position.y, transform.position.z);
        }

        if (transform.position.x > leftBoundry)
        {
            transform.position = new Vector3(leftBoundry, transform.position.y, transform.position.z);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gate1"))
        {
           GateProperty gateProperties =  collision.gameObject.GetComponent<GateProperty>();
            if(gateProperties != null)
            {
                gateParticle.Play(gateParticle);
                gateSound.Raise();
                gateProperties.gateText();
                destroyGateBool.Value = true;

              if(destroyGateBool.Value == true)
                {
                    carRemainingBullets.text = bulletsOnCar.Value.ToString();
                }

            }
        
        }

        if (collision.gameObject.CompareTag("Gate2"))
        {
            GateProperty gateProperties = collision.gameObject.GetComponent<GateProperty>();
            if (gateProperties != null)
            {
                gateParticle.Play(gateParticle);
                gateSound.Raise();
                gateProperties.gateText();
                destroyGateBool2.Value = true;

                if (destroyGateBool2.Value == true)
                {
                    carRemainingBullets.text = bulletsOnCar.Value.ToString();
                   
                }
            }

        }
        
        if (collision.gameObject.CompareTag("Gate3"))
        {
            GateProperty gateProperties = collision.gameObject.GetComponent<GateProperty>();
            if (gateProperties != null)
            {
                gateParticle.Play(gateParticle);
                gateSound.Raise();
                gateProperties.gateText();
                destroyGateBool3.Value = true;

                if (destroyGateBool3.Value == true)
                {
                    carRemainingBullets.text = bulletsOnCar.Value.ToString();
                   
                }
            }

        }  
        
        if (collision.gameObject.CompareTag("Gate4"))
        {
            GateProperty gateProperties = collision.gameObject.GetComponent<GateProperty>();
            if (gateProperties != null)
            {
                gateParticle.Play(gateParticle);
                gateSound.Raise();
                gateProperties.gateText();
                destroyGateBool4.Value = true;

                if (destroyGateBool4.Value == true)
                {
                    carRemainingBullets.text = bulletsOnCar.Value.ToString();
                   
                }
            }

        }
        
        if (collision.gameObject.CompareTag("Gate5"))
        {
            GateProperty gateProperties = collision.gameObject.GetComponent<GateProperty>();
            if (gateProperties != null)
            {
                gateParticle.Play(gateParticle);
                gateSound.Raise();
                gateProperties.gateText();
                destroyGateBool5.Value = true;

                if (destroyGateBool5.Value == true)
                {
                    carRemainingBullets.text = bulletsOnCar.Value.ToString();
                   
                }
            }

        }
      

        else if(collision.gameObject.CompareTag("monster"))
        {
            Destroy(gameObject);
            gameOver = true;
            RestartButton.Raise();
            Time.timeScale = 0f;
        }

        else if (collision.gameObject.CompareTag("car1") || collision.gameObject.CompareTag("Hurdle"))
        {
           
            Destroy(gameObject);
            Destroy(collision.gameObject);
            gameOver = true;

            RestartButton.Raise();
            Time.timeScale = 0f;
        }

    }

    public void scoreAfterDestroyingCars(int scoreToAdd)
    {

        score += scoreToAdd;
        ScoreText.text = score.ToString();
    }

    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchStartPos = Input.GetTouch(0).position;
        }

        

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchCurrentPos = Input.GetTouch(0).position;
            Vector2 Distance = touchCurrentPos - touchStartPos;

            if (Distance.x < 0)
            {
                transform.position = CharacterPosition[0].transform.position;
            }
            if (Distance.x > 0)
            {
                transform.position = CharacterPosition[1].transform.position;

               
            }
            


            //if (Currentpositionindex == 1)
            //{
            //    Currentpositionindex -= 1;

            
            //}
            //if (Currentpositionindex == 0)
            //{
            //    Currentpositionindex += 1;

            //    transform.position = CharacterPosition[Currentpositionindex].transform.position;

            //}


            //if (transform.position.x < rightBoundry)
            //{
            //    transform.position = new Vector3(rightBoundry, transform.position.y, transform.position.z);
            //}

            //if (transform.position.x > leftBoundry)
            //{
            //    transform.position = new Vector3(leftBoundry, transform.position.y, transform.position.z);
            //}

            //if (!swipeIsStop)
            //{
            //    if (Distance.x > swipeRange)
            //    {
            //        // swipe is in right direction
            //        transform.position = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
            //        //this.transform.position = Vector3.Lerp(transform.position, rightAnchor.transform.position, 0.3f);

            //    }

            //    if (Distance.x < -swipeRange)
            //    {
            //        // swipe is in left direction
            //        transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
            //        //this.transform.position = Vector3.Lerp(transform.position, leftAnchor.transform.position, 0.3f);

            //    }
            //}
        }



    }
    void MovePlayerHorizontally()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
            Debug.Log("Move Right");
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {

            transform.position = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
            Debug.Log("Move Left");

        }
    }

    public void UpdateCarBulletsText()
    {
        carRemainingBullets.text = bulletsOnCar.Value.ToString();
    }

    private void OnDestroy()
    {
        playerAnim.enabled = false;
       
    }

}


