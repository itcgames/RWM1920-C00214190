using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    //bool for if sound should be played
    bool playSound;
    // rigidbody of ball
    private Rigidbody2D rigidbody;
    void Start()
    {
        playSound = true;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidbody.angularDrag += 0.5f;
    }

    // used for collision detection
    void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.rigidbody != null)
        {
            if (playSound)
            {
                transform.parent.GetComponent<AudioSource>().Play();
                playSound = false;
            }
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

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!playSound) playSound = true;
    }
}
