using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetBuffManager : MonoBehaviour {
    
    
    Weapon[] weapon = new Weapon[2];
    public float durrationTime;
    bool colidedFR;
    //Fire rate
    public CountDown_FireRate CountDown_FireRate;
    Image NewFireRateImage;
    //Speed Up
    DeadpoolMovement deadpoolMovement;
    public CountDown_SpeedUp CountDown_SpeedUp;
    Image SpeedImage;
    Animator anim;
    // Flame
    Image FlameIcon;
    public CountDown_Flame CountDown_Flame;
    // Multi
    public CountDown_Multi CountDown_Multi;
    Image MultiShotImage;
    public GameObject[] spawnPoints = new GameObject[2];

    // Use this for initialization

    void Awake ()
    {
        weapon = GetComponentsInChildren<Weapon>();
        NewFireRateImage = GameObject.FindGameObjectWithTag("FastShootIcon").GetComponent<Image>();
        SpeedImage = GameObject.FindGameObjectWithTag("SpeedIcon").GetComponent<Image>();
        anim = GetComponent<Animator>();
        deadpoolMovement = GetComponent<DeadpoolMovement>();
        FlameIcon = GameObject.FindGameObjectWithTag("FlameIcon").GetComponent<Image>();
        MultiShotImage = GameObject.FindGameObjectWithTag("MultishotIcon").GetComponent<Image>();
        spawnPoints = GameObject.FindGameObjectsWithTag("Multishot");
    }
	
	// Update is called once per frame
	void Update () {

      

	}

    void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "FireSpeedUp") // jezeli dotknelo się obiektu co przyspiesza strzelanie
        {
            // czas trwania buffa
            CountDown_FireRate.timeLeft += RefreshManager.BuffTime;

        }

        if(other.gameObject.tag == "SpeedUp")
        {

            CountDown_SpeedUp.timeLeft += RefreshManager.BuffTime;

        }

        if(other.gameObject.tag == "Flame")
        {
            
            CountDown_Flame.timeLeft+= RefreshManager.BuffTime;


        }

        if (other.gameObject.tag == "MultiShotIBuff")
        {

            CountDown_Multi.timeLeft += RefreshManager.BuffTime;


        }

    }

   

    // reset wartosci predkosci ataku
    public void ResetFireRate()
    {
        foreach (Weapon element in weapon)
        {
            element.currentTimeBetweenBullets = element.startingTimeBetweenBullets;

        }
        RefreshManager.FireRateisActive = false;
        NewFireRateImage.enabled = false;
    }

     public void ResetSpeed()
    {
        deadpoolMovement.currentSpeed = deadpoolMovement.Startingspeed;
        anim.speed = 1f;
        SpeedImage.enabled = false;
    }


    public void ResetBulletToDefault()
    {

        foreach (Weapon element in weapon)
        {
            element.ResetBulletToDefault();
        }
        FlameIcon.enabled = false;


    }
    public void ResetShoot()
    {
        foreach (GameObject element in spawnPoints)
        {

            element.GetComponent<Weapon>().enabled = false;
        }
        MultiShotImage.enabled = false;
    }



}
