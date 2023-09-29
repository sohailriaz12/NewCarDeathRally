using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RayCast : MonoBehaviour
{

    public GameObject spawner1, spawner2, spawner3, spawner4, spawner5;
    public GameObject BulletPrefab;

    public BoolVariable canNotShoot;

    [SerializeField]private GameObject bulletSpawner;
    //public Animator playerAniamtor;

    // Scriptable objects and Events

    //public delegate void spawnBullets();
    //public UnityEvent onSpawningBullets;
    public GameEvent restartButton;
    public IntVariable bulletsOnCar;
    public GameEvent playerGunSound;
    public IntVariable monsterSpeed;

    public BoolVariable playCarMovingAnim;

    public static RayCast Instance;
    public GameEvent OnReduceCarBulletsBy5;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        playCarMovingAnim.Value = false;
        //playerAniamtor = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        spawner();

    }
    IEnumerator waitToStopMonster()
    {
        yield return new WaitForSeconds(1.2f);
        monsterSpeed.Value = 0;
    }

    GameObject rayCastedGameObject;
    bool isBulletsFired = false;
    void spawner()
    {
        if (canNotShoot.Value == true)
        {
            return;
        }
        RaycastHit hit;
        Vector3 RayPos = new Vector3(bulletSpawner.transform.position.x, bulletSpawner.transform.position.y, bulletSpawner.transform.position.z);

        Ray FiringRay = new Ray(RayPos, transform.forward);
        

        if (Physics.Raycast(FiringRay, out hit, 2))
        {
            Debug.DrawLine(FiringRay.origin, hit.point, Color.red);

            GameObject enemy = hit.collider.gameObject;

            if (enemy != null)
            {
                DetectCollisions enemyInfo = enemy.GetComponent<DetectCollisions>();
                if (enemyInfo != null)
                {
                    if (enemyInfo.gameObject != rayCastedGameObject)
                    {
                        isBulletsFired = false;
                        rayCastedGameObject = enemyInfo.gameObject;

                    }

                    if (!isBulletsFired)
                    {
                        isBulletsFired = true;

                        int bulletsToDestroy = enemyInfo.totalBulletsToDestroy;


                        if (canNotShoot.Value != true)
                        {

                            
                           StartCoroutine(SpawnBullets(bulletsToDestroy));
                        }


                    }

                }
            }



            GameObject monster = hit.collider.gameObject;
            if (monster != null)
            {
                MonsterSpeed monsterSpeedScript = monster.GetComponent<MonsterSpeed>();
                OppositeMoveForward opppositeMonsterSpeed = monster.GetComponent<OppositeMoveForward>();
                if (monsterSpeedScript != null || opppositeMonsterSpeed != null)
                {
                    if (hit.collider.CompareTag("monster"))
                    {
                        playCarMovingAnim.Value = true;
                        //playerAniamtor.gameObject.SetActive(true);
                        StartCoroutine(waitToStopMonster());





                        if (bulletsOnCar.Value <= 0 && canNotShoot.Value == true)
                        {

                            restartButton.Raise();

                        }
                    }



                }
            }

        }
        else
        {
            Debug.DrawLine(FiringRay.origin, FiringRay.origin + FiringRay.direction * 2, Color.green);
        }

    }

    IEnumerator SpawnBullets(int bulletsToDetroy)
    {
        yield return null;

        int numberOfBursts = bulletsToDetroy / 5;
        for (int i = 0; i < numberOfBursts; i++)
        {
            if(canNotShoot.Value == true)
            {
                StopAllCoroutines();
                break;
            }
            Instantiate(BulletPrefab, spawner1.transform.position, BulletPrefab.transform.rotation);
            Instantiate(BulletPrefab, spawner2.transform.position, BulletPrefab.transform.rotation);
            Instantiate(BulletPrefab, spawner3.transform.position, BulletPrefab.transform.rotation);
            Instantiate(BulletPrefab, spawner4.transform.position, BulletPrefab.transform.rotation);
            Instantiate(BulletPrefab, spawner5.transform.position, BulletPrefab.transform.rotation);

            playerGunSound.Raise();
            OnReduceCarBulletsBy5.Raise();
            yield return new WaitForSeconds(0.1f);
        }

        
    }



}

