using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SpeedUp : MonoBehaviour {

    public int SpeedUpAmount = 4 ; // bazowy speed up
    DeadpoolMovement deadpoolMovement;
    GameObject player;
    AudioSource speedUpSound;
    SphereCollider coll;
    public GameObject[] Children = new GameObject[5];
    Animator anim;
    Image SpeedImage;
    
    //animation["Animation name"].speed = 0.5;


    // Use this for initialization
    void Awake() {

        player = GameObject.FindGameObjectWithTag("Player");
        
        deadpoolMovement =player.GetComponent<DeadpoolMovement>();
        speedUpSound = GetComponent<AudioSource>();
        coll = GetComponent<SphereCollider>();
        anim = player.GetComponent<Animator>();

        SpeedImage = GameObject.FindGameObjectWithTag("SpeedIcon").GetComponent<Image>();
     

    }
	
	// Update is called once per frame
	


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            speedUpSound.Play();
            if (deadpoolMovement.currentSpeed < 10)
            {
                anim.speed = 1.5f;// przyśpieszenie animacji biegania
                deadpoolMovement.SpeedBost(SpeedUpAmount);  // jezeli jest juz buff to nie zmieniamy predkosci
                SpeedImage.enabled = true;// a tu aktywowac ikonke

            }
         




            // usuwanie elementu po zebraniu
            foreach (GameObject element in Children)
            {
                Destroy(element);

            }
            coll.enabled = false;


            // po określonym czasie buff znika
            
            Destroy(gameObject,10);


        }// if

    }//ontrigger

    


    
     





}// speedUp class








