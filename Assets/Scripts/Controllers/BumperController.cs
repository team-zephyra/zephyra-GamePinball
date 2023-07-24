using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    [SerializeField] private Color startColor;

    private Renderer renderer;
    private Animator animator;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        startColor = Color.red;
        renderer.material.color = startColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            // Animasi
            animator.SetTrigger("hit");

            if (renderer.material.color == Color.red)
            {
                SwitchColor(Color.yellow);
            } else if (renderer.material.color == Color.yellow)
            {
                SwitchColor(Color.green);
            } else if (renderer.material.color == Color.green)
            {
                SwitchColor(Color.red);
            }
        }
    }

    private void SwitchColor(Color colorToSwitch)
    {
        renderer.material.color = colorToSwitch;
    }


}
