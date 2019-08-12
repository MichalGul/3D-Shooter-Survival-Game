using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class IconControl : MonoBehaviour {

    // skrypt kontrolny iconek, usuwa je z widoku przy wlaczeniu gry




    Image multiShotIcon;
    Image flameIcon;
    Image FireRateIcon;
    Image SpeedUpIcon;


	// Use this for initialization
	void Awake()
    {
        multiShotIcon = GameObject.FindGameObjectWithTag("MultishotIcon").GetComponent<Image>();
        flameIcon = GameObject.FindGameObjectWithTag("FlameIcon").GetComponent<Image>();
        FireRateIcon = GameObject.FindGameObjectWithTag("FastShootIcon").GetComponent<Image>();
        SpeedUpIcon = GameObject.FindGameObjectWithTag("SpeedIcon").GetComponent<Image>();


        multiShotIcon.enabled = false;
        flameIcon.enabled = false;
        FireRateIcon.enabled = false;
        SpeedUpIcon.enabled = false;
    }
   

    // Update is called once per frame
    void Update () {
	
	}
}
