using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource _buttonAudioSource;
    public AudioClip buttonClickAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonAudio()
    {
        _buttonAudioSource.clip = buttonClickAudio;
        _buttonAudioSource.Play();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
