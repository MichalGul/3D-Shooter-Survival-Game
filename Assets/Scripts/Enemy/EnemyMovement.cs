using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    Transform player; //przechowywanie pozycji gracza
    NavMeshAgent nav; //komponent nvmesh
    DeadpoolHealth deadpoolHealth; // odniesienie do gracza
    EnemyHealth enemyHealth; // do wroga
    
    void Awake ()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform; // znajdowanie pozycj gracza
        nav = GetComponent<NavMeshAgent>(); //referencja do komponentu dodanego do szkieletu
        deadpoolHealth = player.GetComponent<DeadpoolHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }


    void Update()
    {
        //zeby nie wyskakiwal blad ze chcemy poruszac czymsc czego nie ma

        if (enemyHealth.currentHealth > 0 && deadpoolHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position); // nav mesh agent zmienina pozycje szkieletu do gracza
        }
     else
        {
            nav.enabled = false;
        }
     

          

    }


    
}
