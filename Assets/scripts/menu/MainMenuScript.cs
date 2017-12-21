using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {
   public GameObject MainMenuCanvas;

	// Use this for initialization
	void Start () {
        Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void QuitGame()
    {
        Application.Quit();
    }
    public void NewGame()
    {
        Application.LoadLevel("PrevievCourseProject");
    }
    public void History()
    {
        Application.LoadLevel("History");
    }
}
