using UnityEngine;
using System.Collections;
using System;

public class Weapon : MonoBehaviour {

    public GameObject DefaultBullet;// prefab pocisku
    public GameObject FireBullet;
    public GameObject currentBullet;
    public Transform shotSpawn; // punky na koncu lufy
    public float startingTimeBetweenBullets; // odstep miedzy strzalami
    public float currentTimeBetweenBullets;
    private float timer;        //timer odmierzajacy czas

    ParticleSystem gunParticles; // particle system dodany do lufy
    AudioSource gunAudio; //dzwiek strzału
    Light gunLight; // swiatło dodane do lufy
    float effectsDisplayTime = 0.2f; //czas trwania efektow swiatla i particlesystemu



    void Awake()
    { // pobieranie referencji do poszczegolnych elementow
        gunParticles = GetComponent<ParticleSystem>();
        gunLight = GetComponent<Light>(); 
        gunAudio = GetComponent<AudioSource>();
        gunParticles = GetComponentInChildren<ParticleSystem>();

        currentTimeBetweenBullets = startingTimeBetweenBullets;
        currentBullet = DefaultBullet;

    }


    void Update()
        {
            timer = timer + Time.deltaTime; // akumulacja czasu

            if (Input.GetButton("Fire1") && timer >= currentTimeBetweenBullets)
            {
          
                Shoot();

            }

            if (timer >= currentTimeBetweenBullets * effectsDisplayTime)
            {
            gunLight.enabled = false; // po krotkim czasie wylacz swiatlo

        }

        }


   
    void Shoot()
    {
        timer = 0f; //reset timera po strzale
        gunAudio.Play();
        gunLight.enabled = true; // efekt swiatla

        gunParticles.Stop(); //jesli wczesniej byla animacja to ja przerwij i zacznij od nowa (przypadek gdy sie szybko strzela)
        gunParticles.Play();



        // podstawowa broń tu mozna dac jakiego ifa ze inne instantiates sie tworza i to bedda inne bronie         
        Instantiate(currentBullet, shotSpawn.position, shotSpawn.rotation); //  //stworzenie pocisku
    }


    public void IncreaseFireRate(float newvalue)
    {
        currentTimeBetweenBullets = newvalue;

    }

    public void ChangeBullet(GameObject newBullet)
    {

        currentBullet = newBullet;

    }
   public void ResetBulletToDefault ()
    {

        currentBullet = DefaultBullet;



    }





}