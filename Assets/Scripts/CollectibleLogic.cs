using UnityEngine;

public class CollectibleLogic : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private Vector3 rotationDirection = new Vector3(0, 1, 0);
    
    void Update()
    {
        transform.Rotate(rotationDirection * (rotationSpeed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerLogic();
        }
    }
    
    void TriggerLogic()
    {
        ScoreManager.instance.AddScore(1);
        Debug.Log("Collectible Picked Up!");
        Destroy(gameObject);
    }
}
