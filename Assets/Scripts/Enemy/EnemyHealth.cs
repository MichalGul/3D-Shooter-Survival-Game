using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 1f; // jak szybko bedzie wnikac w podłoge
    public int scoreValue = 15;

    public AudioClip deathClip; // dzwiek smierci szkieleta

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    Mover Bullet;
    CapsuleCollider capsuleCollider;

    bool Dead;
    bool isSinking;

    void Awake ()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>(); // to samo bedzie przy broni jak strzela
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;

   
    }

    void Update()
    {
            if(isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);//znika w podłoge z predkoscia co sekunde nie co klatke


        }


    }



    public void TakeDamage (int dmg, Vector3 hitPoint)
    {
        if (Dead)
            return;
        enemyAudio.Play();

        currentHealth = currentHealth - dmg;
        hitParticles.transform.position = hitPoint; // przesuniecie systemu w miejsce ataku zastanawiam sie czy to mi bedzie potrzebne
        hitParticles.Play();

        if(currentHealth<=0)
        {

            Death();
        }


    }

    void Death()
    {

        Dead = true;
        capsuleCollider.isTrigger = true; // wylaczenie kolizji
        GetComponent<NavMeshAgent>().enabled = false;
        anim.SetTrigger("Dead");

         enemyAudio.clip = deathClip; //dzwiek smierci szkielete ktorego nie mam jeszcze
         enemyAudio.Play();

    }

    public void StartSinkig()
    {

        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true; // podłoga bedzie ignorowac obiekt zeby mogl przeniknac
        isSinking = true;
        ScoreManager.score += scoreValue;
        Destroy(gameObject, 3f);
    }



    // Zadawanie obrażeń
    void OnCollisionEnter (Collision coll)
    {
        Bullet = coll.collider.GetComponent < Mover >() as Mover; // sprawdzenie czy to co dotknelo objektu ma komponent Mover (czyli bullet)

        if(Bullet!=null) // jezeli to co dotknelo jest pociskiem
        {
            TakeDamage(Bullet.BulletDmg, Bullet.transform.position); // zadaj obrazenia i wyswietl efekt particle system tam gdzie zniknal pocisk


        }


    }


    }
