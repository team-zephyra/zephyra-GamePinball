using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Collider ballCollider;
    private VFXManager VFXManager;
    private AudioManager audioManager;
    [SerializeField] private GameObject gameOverGO;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        VFXManager = FindObjectOfType<VFXManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider == ballCollider)
        {
            // Activate GameOverUI
            gameOverGO.SetActive(true);

            // Play Audio and Visual FX
            audioManager.PlayBombSFX(other.transform.position);
            VFXManager.PlayVFX(other.transform.position);
        }  
    }

    public Transform GetSpawnPosition()
    {
        return spawnPosition;
    }
}
