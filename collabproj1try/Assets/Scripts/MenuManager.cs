using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public static bool gamePaused;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject mainMenu;
    
    // [SerializeField] private GameObject pauseButton;
    // [SerializeField] private GameObject mainButton;
    
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            // if(SceneManager.GetActiveScene().buildIndex == 0)
            // {
            //     EventSystem.current.SetSelectedGameObject(mainButton);
            // }
            // else
            //     EventSystem.current.SetSelectedGameObject(pauseButton);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
        {
            if(SceneManager.GetActiveScene().buildIndex != 0) // dont pause if in the main menu
            {
                gamePaused = !gamePaused;
                GamePaused(gamePaused);
            }
        }
    }

    public void LoadScene(int sceneIndex)
    {
        if(sceneIndex == 0)
        {
            Cursor.lockState = CursorLockMode.None; // keep curson unlocked if in the main menu
            mainMenu.SetActive(true);
            // EventSystem.current.SetSelectedGameObject(mainButton);
        }
        else
        {
            mainMenu.SetActive(false);
            // EventSystem.current.SetSelectedGameObject(pauseButton);
        }
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GamePaused(bool paused)
    {
        gamePaused = paused; // keep the gamePaused variable up to date to whats happening
        if(paused == true)
            Pause();
        if(paused == false)
            UnPause();
    }

    void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    void UnPause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
