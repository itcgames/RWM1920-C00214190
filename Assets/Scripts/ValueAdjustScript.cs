using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueAdjustScript : MonoBehaviour
{
    [Range(0,360)]
    public float startRotation;
    [Range (1,15)]
    public float ballWeight;
    private Rigidbody2D m_ballRB2D;

    private void OnValidate()
    {
        // Get Rigidbody of the Ball part of the wrecking ball
        m_ballRB2D = transform.Find("Ball").gameObject.GetComponent<Rigidbody2D>();
        // Set mass of object
        m_ballRB2D.mass = ballWeight;
        // Set rotation of entire wrecking Ball prefab
        transform.eulerAngles = new Vector3(0, 0, startRotation);
    }

    void Start()
    {
        // Get Rigidbody of the Ball part of the wrecking ball
        m_ballRB2D = transform.Find("Ball").gameObject.GetComponent<Rigidbody2D>();
        // Set mass of object
        m_ballRB2D.mass = ballWeight;
        // Set rotation of entire wrecking Ball prefab
        transform.eulerAngles = new Vector3(0, 0, startRotation);
    }
}
