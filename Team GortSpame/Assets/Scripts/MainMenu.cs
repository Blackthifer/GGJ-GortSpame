using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void exitButton()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void startButton()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void settingsButton()
    {
        SceneManager.LoadScene(2);
    }
    public void creditsButton()
    {
        SceneManager.LoadScene(3);
    }
    
    public void returnButton()
    {
        SceneManager.LoadScene(0);
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen value: " + isFullscreen);
    }
}
