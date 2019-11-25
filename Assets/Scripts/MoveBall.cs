﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    // rigidbody of ball
    private Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidbody.angularDrag += 0.5f;
    }

    void OnCollisionEnter2D(Collision2D otherObject)
    {
        Vector3 force = new Vector3(0, 0, 0)
        {
            x = otherObject.transform.position.x < transform.position.x ? 0.25f : -0.25f
        };
        Vector2 collisionPoint = new Vector2(0, 0)
        {
            x = (transform.position.x + otherObject.rigidbody.position.x) / 2.0f,
            y = (transform.position.y + otherObject.rigidbody.position.y) / 2.0f
        };
        otherObject.rigidbody.AddForceAtPosition(force, collisionPoint);
        rigidbody.AddForceAtPosition(-force, collisionPoint);
    }
}