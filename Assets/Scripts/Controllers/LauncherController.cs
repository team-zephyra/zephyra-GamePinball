using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    [SerializeField] private Collider ballCollider;
    [SerializeField] private KeyCode input;
    [SerializeField] private float force;
    [SerializeField] private float maxTimeHold;
    [SerializeField] private float maxForce;
    private bool isHold;

    private void Start()
    {
        isHold = false;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.collider == ballCollider)
        {
            ReadInput(ballCollider);
        }
    }

    private void ReadInput(Collider other)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(other));
        }
    }

    private IEnumerator StartHold(Collider other)
    {
        float force = 0f;
        float timeHold = 0f;

        isHold = true;

        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        other.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
    }
}
