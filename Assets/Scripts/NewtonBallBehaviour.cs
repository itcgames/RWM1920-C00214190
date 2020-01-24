using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewtonBallBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.parent.parent.GetComponent<NewtonCradleBehavoiur>().UpdateHit(transform.parent.name, collision.transform.parent.name);
    }
}
