using UnityEngine;
using System.Collections;

public class CountDown_FireRate : MonoBehaviour {

    public float timeLeft;
    public ResetBuffManager Reset;

	// Use this for initialization
	void Awake () {

        timeLeft = 0;
	
	}
	
	// Update is called once per frame
	void Update () {


        timeLeft -= Time.deltaTime;

        if (timeLeft <=0.0f)
        {

            Reset.ResetFireRate();
            timeLeft = 0;
        }
	
	}
}
