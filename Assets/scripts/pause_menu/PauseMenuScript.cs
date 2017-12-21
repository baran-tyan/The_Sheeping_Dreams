using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour {

    public bool isPaused;
    public GameObject PauseMenuCanvas;
    public string MainMenu;
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isPaused)
        {
            PauseMenuCanvas.SetActive(true);
        }
        else
            PauseMenuCanvas.SetActive(false);
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Cursor.visible = !Cursor.visible;
        }
	}
    public void Resume()
    {
        isPaused = false;
    }
    public void ToMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
