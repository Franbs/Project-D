using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    Vector3 movement;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.z = 0;

        animator.SetFloat("Speed", movement.magnitude);
    }

    void FixedUpdate()
    {
        if (movement.x > 0)
        {
            transform.localScale = Vector3.one;
        } else if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.Translate(movement * Time.deltaTime * moveSpeed);
    }
}
