using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public AudioSource _buttonAudioSource;
    public AudioClip buttonClickAudio;

    public void ButtonAudio()
    {
        _buttonAudioSource.clip = buttonClickAudio;
        _buttonAudioSource.Play();
    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
}
