using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    private bool isGamePaused = false;

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        //User input to pause/resume game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        //deactivate pause menu and unfreeze game
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void Pause()
    {
        //activate pause menu and freeze game
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void GoToMainScene()
    {
        //return to main scene
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }
}
