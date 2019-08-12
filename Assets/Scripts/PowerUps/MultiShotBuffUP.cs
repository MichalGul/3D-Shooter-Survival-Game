using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MultiShotBuffUP : MonoBehaviour {

   // w tym skrypcie musze dostac sie do dzieci deadpoola i akrywowac te dwa pola shotspawn
    Weapon weapon;
    GameObject player;
    public GameObject[] spawnPoints = new GameObject[2]; // tablica spawn pointow
 
    AudioSource multiShotPickUpSound;
    SphereCollider coll;
    public GameObject[] Children = new GameObject[5];
    Image MultiShotImage;
    


    // Use this for initialization
    void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
       
        multiShotPickUpSound = GetComponent<AudioSource>();
        spawnPoints = GameObject.FindGameObjectsWithTag("Multishot");
        coll = GetComponent<SphereCollider>();
       

        
      //  foreach (GameObject element in spawnPoints)
       // {

         //  element.SetActive(false);
     //   }


        MultiShotImage = GameObject.FindGameObjectWithTag("MultishotIcon").GetComponent<Image>();
        

    }

    // Update is called once per frame



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            multiShotPickUpSound.Play(); // dzwiek
            MultiShotImage.enabled = true;// obrazek
            foreach (GameObject element in spawnPoints)
            {

                element.GetComponent<Weapon>().enabled = true;
            }




            // usuwanie elementu po zebraniu
            foreach (GameObject element in Children)
            {
                Destroy(element);

            }
            coll.enabled = false;


            // po określonym czasie buff znika
           
            Destroy(gameObject, 10);


        }// if

    }//ontrigger

    
    
}
