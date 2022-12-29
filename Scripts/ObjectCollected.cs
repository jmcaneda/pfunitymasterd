using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollected : MonoBehaviour
{
    GameObject gameManagerObj;
    GameManager gameManager;
    AudioSource aS;
    [SerializeField] int cantidadPuntos;
    private void Awake()
    {
        cantidadPuntos = 1;
        aS = gameObject.GetComponent<AudioSource>();
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
            gameManager.FruitsOnLevel++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameManager != null)
        {
            ControladorMarcadores.instance.SumarPuntos(cantidadPuntos);
            aS.Play();
            gameManager.FruitsOnLevel--;
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject,0.5f);
        }
    }
}
