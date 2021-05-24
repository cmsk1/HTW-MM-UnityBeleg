using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    private bool _paused = false;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_paused)
            {
                ClosePauseMenu();
            }
            else
            {
                OpenPauseMenu();
            }
        }
    }


    public void RestartGame()
    {
        ClosePauseMenu();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OpenPauseMenu()
    {
        _paused = true;
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        _paused = false;
        Time.timeScale = 1;
        menu.SetActive(false);
    }
}