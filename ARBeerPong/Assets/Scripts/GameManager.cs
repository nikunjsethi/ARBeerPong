using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource _buttonAudioSource;
    public AudioClip buttonClickAudio;

    public void ButtonAudio()
    {
        _buttonAudioSource.clip = buttonClickAudio;
        _buttonAudioSource.Play();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
