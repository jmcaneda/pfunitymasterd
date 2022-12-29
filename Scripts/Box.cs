using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    GameObject fondo;
    [SerializeField] float boxPosX;
    [SerializeField] float limiteJuego;
    float posicionInicialX, posicionInicialY;

    void Start()
    {
        fondo = GameObject.Find("Fondo");
        limiteJuego = (fondo.GetComponent<SpriteRenderer>().bounds.extents.x) * 2.6f;

        posicionInicialX = transform.position.x;
        posicionInicialY = transform.position.y;

    }

    void Update()
    {
        boxPosX = transform.position.x;
        if (boxPosX < -25 || boxPosX > limiteJuego)
        {
            transform.position = new Vector2(posicionInicialX, posicionInicialY);
        }
    }
}
