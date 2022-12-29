using UnityEngine.Audio;
using System;
using UnityEngine;

public class ControladorMarcadores : MonoBehaviour
{
    public static ControladorMarcadores instance;
    
    [SerializeField] int cantidadPuntos;
    public int CantidadPuntos
    {
        get
        {
            return cantidadPuntos;
        }
        set
        {
            cantidadPuntos = value;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
    public void SumarPuntos(int puntos)
    {
        CantidadPuntos += puntos;
    }
}
