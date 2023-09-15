using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float score;

    void Start()
    {
        ResetScore();
    }

    public void AddScore (float scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
