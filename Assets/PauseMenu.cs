using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public static PauseMenu instance;
    public GameObject pauseMenu;
    public bool isPaused;
    public Button exitButton;
	// Use this for initialization
	void Awake () {
        isPaused = false;
        pauseMenu = GameObject.Find("PauseMenu");
        exitButton = GameObject.Find("exitButton").GetComponent<Button>();
        exitButton.onClick.AddListener(ButtonExitGame);
        pauseMenu.SetActive(false);
        if(pauseMenu == null)
        {
            
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = false;
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
            else
            {
                isPaused = true;
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
        }
	}
    public void ButtonExitGame()
    {
        Debug.Log("We are listening");
        Application.Quit();
    }
}
