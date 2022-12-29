using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderMov : MonoBehaviour
{
    GameObject gameManagerObj;
    GameManager gameManager;
    public Transform[] points;
    public Vector3 destinoSpider;
    public int destPoint = 0;
    public float difPosX;

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
        }
        GotoNextPoint();
    }
    
    void Update()
    {
        difPosX = transform.position.x - destinoSpider.x;
        if ((int)difPosX < 0)
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, 0);
        } else if ((int)difPosX > 0)
        {
            transform.position = new Vector3(transform.position.x - Time.deltaTime, transform.position.y, 0);
        }
        else { GotoNextPoint(); }
        
    }
    
    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        destinoSpider = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

}
