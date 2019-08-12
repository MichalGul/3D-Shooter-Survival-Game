using UnityEngine;
using System.Collections;

public class BackToMenu : MonoBehaviour {




    private ShowPanels showPanels;                      //Reference to the ShowPanels script used to hide and show UI panels
    private bool isPaused;                              //Boolean to check if the game is paused or not
    private StartOptions startScript;                   //Reference to the StartButton script

    //Awake is called before Start()
    void Awake()
    {
        //Get a component reference to ShowPanels attached to this object, store in showPanels variable
        showPanels = GetComponent<ShowPanels>();
        //Get a component reference to StartButton attached to this object, store in startScript variable
        startScript = GetComponent<StartOptions>();
    }
    public void BacktoMenu()
    {

        //Set isPaused to false
        isPaused = false;
        //Set time.timescale to 1, this will cause animations and physics to continue updating at regular speed
        Time.timeScale = 1;
        //call the HidePausePanel function of the ShowPanels script
        showPanels.HidePausePanel();
        Application.LoadLevel("Main Menu");

    }
}
