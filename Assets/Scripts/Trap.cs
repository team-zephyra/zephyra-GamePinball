using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private DeadZone deadZone;
    private bool isCountdownStarted = false;

    private void Start()
    {
        deadZone = FindObjectOfType<DeadZone>();
    }
    // Update is called once per frame
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
            other.transform.position = deadZone.spawnPosition.position;
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
