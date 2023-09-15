using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    [SerializeField] private Collider bola;
    [SerializeField] private Material offMaterial;
    [SerializeField] private Material onMaterial;
    private Renderer switchRenderer;
    private SwitchState state;
    private ScoreManager scoreManager;

    [SerializeField] private float score = 1;

    private void Start()
    {
        switchRenderer = GetComponent<Renderer>();
        scoreManager = FindObjectOfType<ScoreManager>();

        Set(false);

        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            ToggleSet();
        }
    }

    private void Set(bool active)
    {
        if (active == true)
        {
            state = SwitchState.On;
            switchRenderer.material = onMaterial;

            StopAllCoroutines();
        } else
        {
            if (state != SwitchState.Off)
            {
                state = SwitchState.Off;
                switchRenderer.material = offMaterial;

                StartCoroutine(BlinkingLight(2));
            }
            
        }
    }

    private IEnumerator BlinkingLight(int times)
    {
        // Switch state before begin
        state = SwitchState.Blink;
        
        // Begin blinking without changing state
        for (int i = 0; i < times; i++)
        {
            switchRenderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            switchRenderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        // Switch state to off after blinking
        state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(BlinkingLight(2));
    }

    private void ToggleSet()
    {
        // From ON to OFF
        if (state == SwitchState.On)
        {
            Set(false);
        } else // From OFF to ON
        {
            Set(true);
            scoreManager.AddScore(score);
        }
    }
}