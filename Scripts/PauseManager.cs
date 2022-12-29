using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject botonPausa;
    public GameObject botonPlay;
    public GameObject musicVolumen;
    public GameObject fxVolumen;

    public Slider musicVolumenSlider;
    public Slider fxVolumenSlider;

    public AudioMixer masterMixer;

    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;

    public bool gamePause;


    private void Start()
    {
        botonPausa.SetActive(true);
        botonPlay.SetActive(false);
        musicVolumen.SetActive(false);
        fxVolumen.SetActive(false);

    }
   
    public void Pausa()
    {
        gamePause = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        botonPlay.SetActive(true);
        musicVolumen.SetActive(true);
        fxVolumen.SetActive(true);
        paused.TransitionTo(0.01f);
        LoadState();
    }
    public void Reanudar()
    {
        gamePause = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        botonPlay.SetActive(false);
        musicVolumen.SetActive(false);
        fxVolumen.SetActive(false);
        unpaused.TransitionTo(0.01f);
        SaveState();
    }
    void LoadState()
    {
        musicVolumenSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0f);
        fxVolumenSlider.value = PlayerPrefs.GetFloat("FXVolume", 0f);
    }
    void SaveState()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolumenSlider.value);
        PlayerPrefs.SetFloat("FXVolume", fxVolumenSlider.value);
    }
    public void SetFXVolume (float fxVolume)
    {
        masterMixer.SetFloat("FXVolume", fxVolume);
    }
    public void SetMusicVolume (float musicVolume)
    {
        masterMixer.SetFloat("MusicVolume", musicVolume);
    }
}
