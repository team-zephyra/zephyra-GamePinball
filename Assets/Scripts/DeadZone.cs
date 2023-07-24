using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Collider ballCollider;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider == ballCollider)
        {
            other.transform.position = spawnPosition.position;
        }
    }
}
