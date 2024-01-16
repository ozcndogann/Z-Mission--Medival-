using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    void Update()
    {
        if (ThirdPersonShooterController.isdead)
        {
            YouAreDead();
        }
        else
        {
            InputSystem.EnableDevice(Keyboard.current);
        }
    }
    public void YouAreDead()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 1f;
        InputSystem.DisableDevice(Keyboard.current);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("PlayGround");
        gameOverMenu.SetActive(false);

        ThirdPersonShooterController.isdead = false;
        InputSystem.EnableDevice(Keyboard.current);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
