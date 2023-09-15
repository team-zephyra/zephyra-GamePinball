using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    [SerializeField] private Color _startColor;

    private AudioManager _audioManager;
    private Animator _animator;
    private Renderer _renderer;
    private VFXManager _VFXManager;
    private ScoreManager _scoreManager;
    
    [SerializeField] private float score = 1;
    

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _animator = GetComponent<Animator>();

        _startColor = Color.red;
        _renderer.material.color = _startColor;

        _audioManager = FindObjectOfType<AudioManager>();
        _VFXManager = FindObjectOfType<VFXManager>();
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            // Animasi
            _animator.SetTrigger("hit");

            if (_renderer.material.color == Color.red)
            {
                SwitchColor(Color.yellow);
            } else if (_renderer.material.color == Color.yellow)
            {
                SwitchColor(Color.green);
            } else if (_renderer.material.color == Color.green)
            {
                SwitchColor(Color.red);
            }

            // Play Sound FX on Collision
            _audioManager.PlayBumpSFX(collision.transform.position);

            // Play Particle Effect on Collision
            _VFXManager.PlayVFX(collision.transform.position);

            // Add score
            _scoreManager.AddScore(score);
        }
    }

    private void SwitchColor(Color colorToSwitch)
    {
        _renderer.material.color = colorToSwitch;
    }
}
