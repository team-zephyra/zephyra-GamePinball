using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private AudioManager audioManager;
    private DeadZone deadZone;
    private bool isCountdownStarted = false;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        deadZone = FindObjectOfType<DeadZone>();
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
