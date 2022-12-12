using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource _buttonAudioSource;
    public AudioClip buttonClickAudio;
    [SerializeField] AudioSource _collisionAudioSource;
    [SerializeField] AudioClip collisionAudio;
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

    public void CollisionAudio()
    {
        _collisionAudioSource.clip = collisionAudio;
        _collisionAudioSource.Play();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
