using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlatformMover mover = other.GetComponent<PlatformMover>();
        
        if (mover != null)
        { 
            this.gameObject.transform.SetParent(other.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlatformMover mover = other.GetComponent<PlatformMover>();
        if (mover != null)
        {
            transform.SetParent(null);
        }
    }
}
