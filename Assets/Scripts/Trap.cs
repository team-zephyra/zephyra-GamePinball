using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private AudioManager audioManager;
    private DeadZone deadZone;
    private ScoreManager scoreManager;
    private bool isCountdownStarted = false;
    [SerializeField] private float score = -1;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        deadZone = FindObjectOfType<DeadZone>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        if (!isCountdownStarted)
        {
            StartCoroutine(DestroyTrapCountdown());
            isCountdownStarted = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallController>() != null)
        {
            other.transform.position = deadZone.GetSpawnPosition().position;
            audioManager.PlayBombSFX(transform.position);
            DestroyTrap();
            scoreManager.AddScore(score);
        }    
    }

    private IEnumerator DestroyTrapCountdown()
    {
        yield return new WaitForSeconds(10f);
        DestroyTrap();
    }

    private void DestroyTrap()
    {
        SpawnManager.trapSpawned--;
        Destroy(this.gameObject);
    }
}
