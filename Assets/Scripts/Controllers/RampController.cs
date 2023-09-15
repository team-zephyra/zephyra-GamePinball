using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampController : MonoBehaviour
{
    private ScoreManager scoreManager;
    [SerializeField] private Collider bola;
    [SerializeField] private float score = 1;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            scoreManager.AddScore(score);
        }
    }
}
