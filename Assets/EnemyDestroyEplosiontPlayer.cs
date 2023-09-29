using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyEplosiontPlayer : MonoBehaviour
{
    public ParticleSystem explosionPrefab;
    public AudioSource sources;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEnemyDestroyExplosion()
    {
        explosionPrefab.Play();
        sources.PlayOneShot(clip);
    }
}
