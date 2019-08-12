using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour {

    Text text;
    public float time;
    public DeadpoolHealth playerHealth;
    bool playerDead;
	// Use this for initialization
	void Awake () {

        text = GetComponent<Text>();
        time = 0;
        
	}
	
	// Update is called once per frame
	void Update () {


        if (playerHealth.currentHealth > 0)
        {

            time = time + Time.deltaTime; // cały czas ktory minął
        }


        
   
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

     //   GUI.Label(new Rect(10, 10, 250, 100), niceTime);


        text.text = "Time: " + niceTime;

     



	
	}
}
