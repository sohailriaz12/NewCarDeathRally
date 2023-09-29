using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectCollisions : MonoBehaviour
{


  
    [SerializeField] private GameObjectReference player;

    private PlayerController playerControllerScript;
    //private MoveForward roadMovmentScript;
    //private RepeatBackGround repeatBackgroundScript;
    private float lowerBound = 13f;

    
    public int totalBulletsToDestroy ;

    //public ParticleSystem Explosionprefab;

    public int totalBulletsHitted = 0;

    public TextMeshPro carRoofText;
    
    public int scoreToDestroy;

    private AudioSource carAudioSource;
    public AudioClip carAudioClip;

    public ParticleSystem levelCompleteCelebration1, levelCompleteCelebration2;
    // Scriptable Objects and Events
    public GameEvent onEnemyDestroyExplosion;
    public BoolVariable playAnimation;
    public BoolVariable showYouWin;
    public BoolVariable playCarMovingAnim;
    public BoolVariable makeSpeedZero;
    // Start is called before the first frame update
    void Start()
    {
       playerControllerScript = player.Value.GetComponent<PlayerController>();
       
        carAudioSource = GetComponent<AudioSource>();
        playAnimation.Value = false;
        showYouWin.Value = false;
        makeSpeedZero.Value = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z > lowerBound)
        {
            Destroy(gameObject);

        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
     

        Destroy(other.gameObject);

        totalBulletsHitted += 1;
        scorOnQuad();
       // playerControllerScript.CarBulletsLeft();
     

        if (totalBulletsHitted == totalBulletsToDestroy)
        {

          
             playerControllerScript.scoreAfterDestroyingCars(5);
            //this.Explosionprefab.Play();
            onEnemyDestroyExplosion.Raise();
            //explosionposition = this.transform.position;

            //OnPLayEnemyDestroyExplosion.Raise();

            StartCoroutine(waitToDestroy());

            //for (int i = 0; i < transform.childCount - 1; i++)
            //{

            //    //transform.GetChild(i).gameObject.SetActive(false);
            //    //this.gameObject.GetComponent<BoxCollider>().enabled = false;

            //    carAudioSource.PlayOneShot(carAudioClip);
            //    StartCoroutine(waitToDestroy());

            //}
            if (gameObject.CompareTag("monster"))
            {
               //roadMovmentScript.enabled = false;
                //repeatBackgroundScript.enabled = false;
                playAnimation.Value = true;
              
                levelCompleteCelebration1.Play();
                levelCompleteCelebration2.Play();
                showYouWin.Value = true;
                playCarMovingAnim.Value = false;
                makeSpeedZero.Value = true;
            }

        }

    }

    void scorOnQuad()
    {
        scoreToDestroy -= 1;
        carRoofText.text = scoreToDestroy.ToString();
    }
    IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(.1f);
        Destroy(this.gameObject);
    }
   


}
