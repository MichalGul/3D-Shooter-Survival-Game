using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

    public DeadpoolHealth playerHealth;
    public float restartDelay = 20f;


    Animator anim;
    float restartTimer=0;


    void Awake()
    {
        anim = GetComponent<Animator>();

    }


    void Update()
    {

        if(playerHealth.currentHealth <= 0 )
        {

            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;
           
                if(restartTimer>=restartDelay)
            {


                playerHealth.RestartGame();


            }




        }



    }


}
