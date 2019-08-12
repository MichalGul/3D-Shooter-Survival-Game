using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {

    public static int score; // zmienna statyczna, nie nalezy do instancj klasyyyy

    Text text;

	// Use this for initialization
	void Awake () {
        text = GetComponent<Text>();
        score = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

        text.text = "Score: " + score;

        
    }
}
