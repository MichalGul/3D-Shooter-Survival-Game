using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FireRateUp : MonoBehaviour {

    public float testowy;
    public float NewFireRateValue = 0.15f; // nowa predkość strzelania
    Weapon[] weapon = new Weapon[2];
    GameObject player;
    AudioSource reload;
    SphereCollider coll;
    public GameObject[] Children = new GameObject[5];
    Image NewFireRateImage;
    
    public bool isActive; // flaga stwierdzajaca czy buff jest aktywny

    // Use this for initialization
    void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
      
        reload = GetComponent<AudioSource>();
        coll = GetComponent<SphereCollider>();
        NewFireRateImage = GameObject.FindGameObjectWithTag("FastShootIcon").GetComponent<Image>();
      
        
        
    }

    // Update is called once per frame
      
     

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            RefreshManager.FireRateisActive = true;
            reload.Play();
            weapon = player.GetComponentsInChildren<Weapon>();
                foreach (Weapon element in weapon) // dla wszystkich strzal zwiekszenie szybkosci
                {
                    if (element.currentTimeBetweenBullets >= 0.3)
                    {

                        element.IncreaseFireRate(NewFireRateValue);  // jezeli jest juz buff to nie zmieniamy predkosci strzelania
                        NewFireRateImage.enabled = true;// a tu aktywowac ikonke

                    }
                }
            

            // usuwanie elementu po zebraniu
            foreach (GameObject element in Children)
            {
                Destroy(element);

            }
            coll.enabled = false;

             StartCoroutine(DestroyTimer()); // niszczenie obiektu po chwili
            


        }// if

    }//ontrigger


    
    
    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);

    }


}
