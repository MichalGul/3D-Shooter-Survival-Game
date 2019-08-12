using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {


    //public float timeBetweenAttacks = 0.5f; // tu musi byc długośc animacji
    public int attackDamage = 15;


    Animator anim;
    GameObject player;
    DeadpoolHealth deadpoolHealth;  // skrypt do healthpacka bedzie musiał mieć takie samo odniesienie do skryptu hp gracza
    bool playerInRange;
    float timer;
    

    void Awake ()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag ("Player");
        deadpoolHealth = player.GetComponent<DeadpoolHealth>();
    }



    void OnTriggerEnter(Collider other) // other co kolwiek co wejdzie w kolizje
    {

        if(other.gameObject == player) // jezeli w obszar sferycznego colidera wszedł gracz
        {
            
            //ustawienie flagi ataku
            playerInRange = true;
            anim.SetBool("InRange", playerInRange);
        }

    }

    void OnTriggerExit (Collider other)
    {

        if(other.gameObject == player)
        {
           
            playerInRange = false;
            anim.SetBool("InRange", playerInRange);
        }


    }

    void Update ()
    {
       // timer = timer + Time.deltaTime;
       // if(timer >= timeBetweenAttacks && playerInRange ==true) // jezeli czas od poprzedniego ataku jest wystarczajacy i gracz w zasiegu
       // {
            //wywołanie funkcji ataku
           
           // Attack (); // ta funkcje wywołuje animator
        
       // }
        //jezeli gracz jest martwy
        if(deadpoolHealth.currentHealth <=0)
        {
            //odpalamy animacje idle ->nie poruszaja sie szkielety
            playerInRange = false;
            anim.SetBool("InRange", playerInRange);

            anim.SetTrigger("PlayerDead");

        }

    }
    // jest wywolywana w animation evencie zeby obrazenia zgrały sie z animacja
    void Attack()
    {

        
        if (deadpoolHealth.currentHealth > 0)
        {

            deadpoolHealth.TakeDamage(attackDamage); // zadajemy obrazenia

        }
        //timer = 0f;

    }

}
