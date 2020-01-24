using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewtonCradleBehavoiur : MonoBehaviour
{
   
    [Range(-90, 90)]
    public float startAngleRotation;

    private List<Transform> m_wreckingBalls;

    //public Transform m_ball;
    bool leftMoving;
  

    // Start is called before the first frame update
    void Start()
    {
        m_wreckingBalls = new List<Transform>();
        leftMoving = true;
        foreach (Transform child in transform)
        {
            if (child.GetComponentInChildren<Rigidbody2D>() != null)
            {
                m_wreckingBalls.Add(child);
            }
        }
        m_wreckingBalls[0].eulerAngles = new Vector3(0, 0, startAngleRotation);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var ball in m_wreckingBalls)
        {
            if (ball != m_wreckingBalls[0])
            {
                ball.localPosition = new Vector3(ball.localPosition.x, m_wreckingBalls[1].localPosition.y, ball.localPosition.z);
            }
        }
        if(true)
        {
            Debug.Log("Hitting");
        }

    }

    // function that adds extra force to the balls at the end of the cradle to simulate movement better
    public void UpdateHit(string colliderName, string otherColliderName)
    {
        if (leftMoving)
        {
            foreach(Transform child in m_wreckingBalls[4])
            {
                if(child.tag == "Ball")
                {
                    if(child.localPosition.y >= 0)
                    {
                        m_wreckingBalls[4].GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2(200, 200));
                        leftMoving = false;
                    }
                }
            }
        }
        else if (!leftMoving)
        {
            foreach (Transform child in m_wreckingBalls[0])
            {
                if (child.tag == "Ball")
                {
                    if (child.localPosition.y <= -2.5)
                    {
                        m_wreckingBalls[0].GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2(-200, -200));
                        leftMoving = true;
                    }
                }
            }
        }
    }

    // function that checks to see if the expected values equals either of the two string values
    private bool CompareStrings(string stringOne, string stringTwo, string expectedValueOne, string expectedValueTwo)
    {
        return ((stringOne == expectedValueOne && stringTwo == expectedValueTwo) || (stringOne == expectedValueTwo && stringTwo == expectedValueOne));
    }
}
