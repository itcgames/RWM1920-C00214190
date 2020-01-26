using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewtonCradleBehavoiur : MonoBehaviour
{

    [Range(-90, 90)]
    public float startAngleRotation;

    private List<Transform> m_wreckingBalls;

    [Range(1, 6)]
    public int distanceBetweenBalls;


    

    // Start is called before the first frame update
    void Start()
    {
        Initialise();
    }

    private void OnValidate()
    {
        Initialise();
    }
   
    private void Initialise()
    {
        float xPosition = 0.0f;
        m_wreckingBalls = new List<Transform>();
        foreach (Transform child in transform)
        {
            if (child.GetComponentInChildren<Rigidbody2D>() != null)
            {
                child.localPosition = new Vector3(xPosition, child.localPosition.y, child.localPosition.z);
                m_wreckingBalls.Add(child);
                xPosition += (1.1f + (distanceBetweenBalls * 0.1f));
            }
        }
        m_wreckingBalls[0].eulerAngles = new Vector3(0, 0, startAngleRotation);
    }
}
