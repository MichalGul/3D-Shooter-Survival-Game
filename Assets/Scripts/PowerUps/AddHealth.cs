using UnityEngine;
using System.Collections;

public class AddHealth : MonoBehaviour {


    public int HealAmount = 20; // bazowy heal healthpacka
    DeadpoolHealth deadpoolHealth;
    GameObject player;
    AudioSource HealSound;
    SphereCollider coll;
     public GameObject[] Children = new GameObject[3];

	// Use this for initialization
	void Awake () {

       
        player = GameObject.FindGameObjectWithTag("Player");
        deadpoolHealth = player.GetComponent<DeadpoolHealth>();
        HealSound = GetComponent<AudioSource>();
        coll = GetComponent<SphereCollider>();       
        

    }
	
	

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            
            if (deadpoolHealth.currentHealth + HealAmount >= deadpoolHealth.startingHealth) // jezeli obrazenia mniesze niz heal
            {
                deadpoolHealth.currentHealth = deadpoolHealth.startingHealth; // maksujemy hp
                deadpoolHealth.healthSlider.value = deadpoolHealth.startingHealth;
            }
            else
            {
                //dodajemy zycie
                deadpoolHealth.HealthUP(HealAmount);
            }

            HealSound.Play();
            // usuwanie dzieci obiektu
            foreach (GameObject element in Children)
            {
                Destroy(element);

            }
            coll.enabled = false;
            Destroy(gameObject,2f);
        }


    }

}
