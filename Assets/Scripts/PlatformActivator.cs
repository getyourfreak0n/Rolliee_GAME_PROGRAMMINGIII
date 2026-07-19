using UnityEngine;

public class PlatformActivator : MonoBehaviour
{
    PlatformMover platformMover;

    void Awake()
    {
        platformMover = GetComponent<PlatformMover>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            platformMover.enabled = true;    
        }
    }
}
