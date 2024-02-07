using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour
{
    public string playerTag = "Player";
    public UnityEvent triggeredEvent;
    public bool triggerOnce = true; // Default to true for safety

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            triggeredEvent.Invoke();

            if (triggerOnce)
            {
                Destroy(gameObject); // "this" is not necessary when destroying the script's GameObject
            }
        }
    }
}
