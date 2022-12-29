using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamera : MonoBehaviour
{
    public Vector2 minCamPos, maxCamPos;
    public GameObject player;
    public float movSuave, posX, posY;
    private Vector2 velocidad;
    void Awake()
    {
        movSuave = 0.2f;
        minCamPos.x = -19;
        maxCamPos.x = 19;
    }

    void Update()
    {
        posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocidad.x, movSuave);
        posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocidad.y, movSuave);

        transform.position = new Vector3(Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posY, minCamPos.y, maxCamPos.y), transform.position.z);
    }
}
