using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moscardon : MonoBehaviour
{
    private float posX, posY;
    public int frequenz, amplitude;
    GameObject gameManagerObj;
    GameManager gameManager;

    private void Awake()
    {
        amplitude = 2;
        frequenz = 2;
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
            gameManager.EnemigosOnLevel++;
            posX = transform.position.x;
            posY = transform.position.y;
            
        }
    }
    private void Update()
    {
        
        posX = posX - Time.deltaTime;
        if (posX < -28)
        {
            posX = 24;
        }
        else
        {
            posY = Mathf.Sin(posX * frequenz) * amplitude;
        }
        transform.position = new Vector2(posX, posY);
    }
   
}
