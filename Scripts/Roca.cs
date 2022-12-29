using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roca : MonoBehaviour
{
    Vector2 moveDirection;
    Vector2 currentVelocity;
    [SerializeField] Rigidbody2D rigidBody2D;

    void FixedUpdate()
    {
        currentVelocity = rigidBody2D.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveDirection = Vector2.Reflect(currentVelocity, collision.GetContact(0).normal);
        rigidBody2D.velocity = moveDirection;
    }
}
