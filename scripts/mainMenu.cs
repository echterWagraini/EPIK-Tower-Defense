using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene("mAP");
        Time.timeScale = 1;
    }
    public void returnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void doExit()
    {
        Application.Quit();
    }
    public void openSettings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void closeSettings()
    {
        SceneManager.LoadScene("mAP");
    }
}
