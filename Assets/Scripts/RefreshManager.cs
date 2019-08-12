using UnityEngine;
using System.Collections;

public class RefreshManager : MonoBehaviour {

    public static float FireRateRefreshTime;
    public static float BuffTime;
    public static bool FireRateisActive;

	// Use this for initialization
	void Awake () {

        FireRateRefreshTime = 0;
        BuffTime = 10;
        FireRateisActive = false;
    }
	
	// Update is called once per frame
	
}
