using System;
using UnityEngine;


public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlatformMover>())
        { 
            this.gameObject.transform.SetParent(other.transform);
            Debug.Log("Collision Enter");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlatformMover>())
        {
            transform.SetParent(null);
            Debug.Log("Collision Exit");
        }
    }
}
