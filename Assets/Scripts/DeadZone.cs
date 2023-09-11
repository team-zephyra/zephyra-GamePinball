using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Collider ballCollider;
    private VFXManager VFXManager;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        VFXManager = FindObjectOfType<VFXManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Play Audio and Visual FX
            audioManager.PlayBombSFX(other.transform.position);
            VFXManager.PlayVFX(other.transform.position);

            // Reset Position to Spawn Position
            other.transform.position = spawnPosition.position;
        }  
    }
}
