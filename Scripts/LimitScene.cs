using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LimitScene : MonoBehaviour
{
    private GameObject gameManagerObj;
    private GameManager gameManager;
    private int nextScene;
    private void Awake()
    {
        nextScene = 1;

    }
    private void Start()
    {
        gameManagerObj = GameObject.Find("GameManager");
        if (gameManagerObj == null)
        {
            Debug.Log("Objeto no encontrado");
        }
        else
        {
            gameManager = gameManagerObj.GetComponent<GameManager>();
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
    private void Update()
    {
        if (gameManager.FruitsOnLevel == 0)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision != null && collision.tag == "Player") 
        {
            if (GetComponent<BoxCollider2D>().offset.x > 0) 
            {
                nextScene += 1;

            } else
            {
                nextScene -= 1;
            }
            SceneManager.LoadScene(nextScene);
        }
    }
}
