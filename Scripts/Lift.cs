using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] float speedCircle;
    [SerializeField] bool changeDirection;

    private void Awake()
    {
        speedCircle = 1f;
        changeDirection = true;
    }

    void Update()
    {
        if (transform.position.y < 4f && changeDirection)
        {
            transform.position += Vector3.up * Time.deltaTime * speedCircle;
        }
        else if (transform.position.y > 0f)
        {
            transform.position += Vector3.down * Time.deltaTime * speedCircle;
        }
        if (transform.position.y >= 4f || transform.position.y <= 0f)
        {
            changeDirection = !changeDirection;
        }
    }
    
}
