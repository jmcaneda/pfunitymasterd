using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turismo : MonoBehaviour
{
    public GameObject player;
    public float velocidad;
    GameObject fondo;
    AudioSource aSMotor;
    float limiteJuego, posicionInicialX, posicionInicialY;
    [SerializeField] private float offsetX;
    private void Awake()
    {
        velocidad = 5f;
        aSMotor= GetComponent<AudioSource>();
        aSMotor.spatialBlend = 1f;
    }
    void Start()
    {
        fondo = GameObject.Find("Fondo");
        limiteJuego = (fondo.GetComponent<SpriteRenderer>().bounds.extents.x)*2.6f;

        posicionInicialX = transform.position.x;
        posicionInicialY = transform.position.y;
        
    }

    void Update()
    {
        offsetX = transform.position.x - player.transform.position.x;
        Vector2 movimiento = new Vector2(Time.deltaTime * velocidad, 0);

        transform.Translate(movimiento);

        if (transform.position.x > limiteJuego * 1.25f)
        {
            transform.position = new Vector2(posicionInicialX, posicionInicialY);
        }

    }
   
}
