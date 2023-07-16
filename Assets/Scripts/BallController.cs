using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody ballRb;

    [Tooltip("Set the maximum speed of this game object")]
    [SerializeField] private float maxSpeed;


    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballRb.velocity.magnitude > maxSpeed)
        {
            ballRb.velocity = ballRb.velocity.normalized * maxSpeed;
        }
    }
}
