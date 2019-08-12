using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FlameBulletsBuff : MonoBehaviour {




    // Weapon weapon;
    Weapon[] weapon = new Weapon[3];
    GameObject player;
    public GameObject BuffedBullet;
    AudioSource pickUpFlameSound;
    SphereCollider coll;
    public GameObject[] Children = new GameObject[4];
    Image FlameIcon;
    


    // Use this for initialization
    void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
      
        pickUpFlameSound = GetComponent<AudioSource>();
        coll = GetComponent<SphereCollider>();

        FlameIcon = GameObject.FindGameObjectWithTag("FlameIcon").GetComponent<Image>();
        

    }

    // Update is called once per frame



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            pickUpFlameSound.Play();
            weapon = player.GetComponentsInChildren<Weapon>();
            foreach (Weapon element in weapon)
            {
                element.ChangeBullet(BuffedBullet);
            }          
            FlameIcon.enabled = true;


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
