using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    bool loadingScene;
    [SerializeField] AudioSource aS;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
    }
    public void StartGame()
    {
        if (loadingScene == true)
        {
            return;
        }
        aS.Play();
        StartCoroutine(LoadGameScene("Scene00"));
    }
    public void QuitGame()
    {
        aS.Play();
        Application.Quit();
    }

    IEnumerator LoadGameScene(string sceneName)
    {
        loadingScene = true;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}

