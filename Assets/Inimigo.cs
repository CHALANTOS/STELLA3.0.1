using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float walkSpeed = 3f;
    Rigidbody2D rb;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
        rb.velocity = new Vector2(walkSpeed * Vector2.right.x, rb.velocity.y);
    }
}
