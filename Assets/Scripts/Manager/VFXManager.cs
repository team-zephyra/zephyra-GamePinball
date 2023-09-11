using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] private GameObject bumpVFXPrefab;

    public void PlayVFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(bumpVFXPrefab, spawnPosition, Quaternion.identity);
    }
}
