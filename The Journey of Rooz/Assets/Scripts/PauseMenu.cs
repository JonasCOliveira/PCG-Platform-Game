
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape)){

            if(GameIsPaused){

                Resume();
            }
            else {

                Pause();
            }
        }

    }

    public void Resume(){


        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause(){

        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu(){

        SceneManager.LoadScene("MenuScene");

    }

    public void QuitGame(){

        Debug.Log("Quiting Game...");
        Application.Quit();

    }

}
