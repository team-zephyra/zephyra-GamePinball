using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float zRotation;
    private bool isCountdownStarted = false;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0f, 0f, zRotation);
        
        if (!isCountdownStarted)
        {
            StartCoroutine(DestroyCoinCountdown());
            isCountdownStarted = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallController>() != null)
        {
            DestroyCoin();
        }    
    }

    private IEnumerator DestroyCoinCountdown()
    {
        yield return new WaitForSeconds(10f);
        DestroyCoin();
    }

    private void DestroyCoin()
    {
        SpawnManager.coinSpawned--;
        Destroy(this.gameObject);
    }
}
