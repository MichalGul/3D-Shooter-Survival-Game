using UnityEngine;
using System.Collections;

public class CountDown_SpeedUp : MonoBehaviour {

    public float timeLeft;
    public ResetBuffManager Reset;


    // Use this for initialization
    void Awake () {

        timeLeft = 0;
    }
	
	// Update is called once per frame
	void Update () {

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0f)
        {

            Reset.ResetSpeed();
            timeLeft = 0;
        }




    }
}
