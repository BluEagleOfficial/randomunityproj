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
    [SerializeField] private GameObject playerHud;
    [SerializeField] private GameObject mainMenu;

    private bool lockCursor;
    
    // [SerializeField] private GameObject pauseButton; // these make the buttons auto select so you can use arrow keys or any input to navigate the buttons, will add later if time
    // [SerializeField] private GameObject mainButton;
    
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                // lockCursor = false;
                Cursor.lockState = CursorLockMode.None;
                mainMenu.SetActive(true);
                playerHud.SetActive(false);
                // EventSystem.current.SetSelectedGameObject(mainButton);
            }
            else
            {
                lockCursor = true;
                mainMenu.SetActive(false);
                playerHud.SetActive(true);
                // EventSystem.current.SetSelectedGameObject(pauseButton);
            }
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

        LockCursor(lockCursor);
        if(Input.GetKeyDown(KeyCode.L))
            lockCursor = !lockCursor;
    }

    public void LoadScene(int sceneIndex)
    {
        if(sceneIndex == 0)
        {
            lockCursor = false; // keep curson unlocked if in the main menu
            mainMenu.SetActive(true);
            playerHud.SetActive(false);
            // EventSystem.current.SetSelectedGameObject(mainButton);
        }
        else
        {
            lockCursor = true;
            mainMenu.SetActive(false);
            playerHud.SetActive(true);
            // EventSystem.current.SetSelectedGameObject(pauseButton);
        }
        GamePaused(false);
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void LockCursor(bool LockCursor)
    {
        if(LockCursor == true)
            Cursor.lockState = CursorLockMode.Locked;
        if(LockCursor == false)
            Cursor.lockState = CursorLockMode.None;
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
        lockCursor = false;
    }

    void UnPause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        lockCursor = true;
    }
}
