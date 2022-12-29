using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject mensaje;
    private SpriteRenderer spR;
    private GameObject gameManagerObj;
    private GameManager gameManager;
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
        }
        spR = mensaje.GetComponent<SpriteRenderer>();
        Color color = spR.material.color;
        color.a = 0f;
        spR.material.color = color;
    }
    private void Update()
    {
        if (gameManager.FruitsOnLevel == 0)
        {
            StartCoroutine("FadeIn");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameManager.FruitsOnLevel == 0)
        {
            StartCoroutine("FadeIn");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameManager.FruitsOnLevel == 0)
        {
            StartCoroutine("FadeOut");
        }
    }
    IEnumerator FadeIn()
    {
        for (float f = 0f; f<=1; f+=0.02f)
        {
            Color color = spR.material.color;
            color.a = f;
            spR.material.color = color;
            yield return (0.05f);
        }
    }
    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= 0; f -= 0.02f)
        {
            Color color = spR.material.color;
            color.a = f;
            spR.material.color = color;
            yield return (0.05f);
        }
    }
}
