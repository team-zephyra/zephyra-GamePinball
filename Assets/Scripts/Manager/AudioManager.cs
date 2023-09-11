using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource BGMAudioSource;
    [SerializeField] private GameObject SFXBumpPrefab;
    [SerializeField] private GameObject SFXBombPrefab;

    // Start is called before the first frame update
    void Start()
    {
        PlayBGM();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBGM()
    {
        BGMAudioSource.Play();
    }

    public void StopBGM()
    {
        BGMAudioSource.Stop();
    }

    public void PlayBumpSFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(SFXBumpPrefab, spawnPosition, Quaternion.identity);
    }

    public void PlayBombSFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(SFXBombPrefab, spawnPosition, Quaternion.identity);
    }
}
