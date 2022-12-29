using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winnerPanel;
    [SerializeField] GameObject[] livesImg;
    [SerializeField] GameObject exitArrow;
    [SerializeField] TMP_Text gameTimeText;
    [SerializeField] TMP_Text gameScoreText;
    [SerializeField] AudioClip buttonPress;
    [SerializeField] bool showUI;
    private GameObject gameManagerObj;
    private GameManager gameManager;
    AudioSource aS;
    public int sceneIndex;
    bool loadingScene;
    private void Awake()
    {
        showUI= false;
        if (exitArrow != null) { exitArrow.SetActive(false); }
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void Start()
    {
        gameManagerObj = GameObject.Find("GameManager");
        if (gameManagerObj == null)
        {
            Debug.Log("Objeto no encontrado");
        }
        else
        {
            gameManager = gameManagerObj.GetComponent<GameManager>();
        }
        aS= GetComponent<AudioSource>();
        losePanel.SetActive(false);
        winnerPanel.SetActive(false);
    }
    private void Update()
    {
        gameScoreText.text = "Score: " + ControladorMarcadores.instance.CantidadPuntos.ToString() + " p";
        gameTimeText.text = "Time: " + Mathf.Floor(gameManager.gameTime).ToString() + " s";

        if (sceneIndex > 1)
        {
            showUI= true;
        } else { showUI= false; }
        
    }
    public void ActivateLosePanel()
    {
        if (showUI) 
        {
            winnerPanel.SetActive(false);
            losePanel.SetActive(true);
            Time.timeScale= 0;

        } else { return; }
       
    }
    public void ActivateWinnerPanel()
    {
        if (showUI)
        {
            losePanel.SetActive(false);
            winnerPanel.SetActive(true);
            Time.timeScale= 0;

        } else 
        { 
            exitArrow.SetActive(true);
            return; 
        }
    }
    public void RestartCurrentScene()
    {
        Time.timeScale = 1;
        ControladorMarcadores.instance.CantidadPuntos = gameManager.parcialPuntos ;
        aS.Play();
        StartCoroutine(LoadNextScene(SceneManager.GetActiveScene().name));
        losePanel.SetActive(false);
        winnerPanel.SetActive(false);
    }
    public void GoToMainMenu()
    {
        if (loadingScene == true)
        {
            return;
        }
        Time.timeScale = 1;
        ControladorMarcadores.instance.CantidadPuntos = 0; 
        gameManager.startTime = Time.time;
        aS.Play();
        StartCoroutine(LoadNextScene("MainMenu"));
        losePanel.SetActive(false);
        winnerPanel.SetActive(false);
    }
    public void GoToNextLevel()
    {
        if (loadingScene == true)
        {
            return;
        }
        Time.timeScale = 1;
        aS.Play();
        StartCoroutine(LoadNextScene("Scene02"));
        losePanel.SetActive(false);
        winnerPanel.SetActive(false);
    }
    IEnumerator LoadNextScene(string sceneName)
    {
        loadingScene = true;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
    public void UpdateUILives(byte currentLives)
    {
        for (int i = 0; i < livesImg.Length; i++)
        {
            if (i >= currentLives)
            {
                livesImg[i].SetActive(false);
            } else
            {
                livesImg[i].SetActive(true);
            }
        }
    }
}