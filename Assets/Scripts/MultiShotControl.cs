using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MultiShotControl : MonoBehaviour {

    /*
  poczatkowe usuwanie multistrzelania
    */

    GameObject[] spawnPoints = new GameObject[2];


	// Use this for initialization
	void Awake ()
    {

        spawnPoints = GameObject.FindGameObjectsWithTag("Multishot"); //znajdowanie punktow spawnu
        //multiShot = GameObject.FindGameObjectWithTag("Multishot").GetComponent<MultiShotBuffUP>();
        // wylaczamy w tych punktach skrypty broni
        foreach (GameObject element in spawnPoints)
        {
            element.GetComponent<Weapon>().enabled = false;
          
        }


    }
	
	// Update is called once per frame
	void Update () {


        /*
                if(GameObject.FindGameObjectWithTag("MultiShotIBuff") !=null )// jezeli mamy buffa na mapie
                {



                    multiShot.spawnPoints[0] = spawnPoints[0];
                    multiShot.spawnPoints[1] = spawnPoints[1];

                }
                */

    }


}
