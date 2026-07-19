using UnityEngine;

public class PlatformRotator : MonoBehaviour, IPlatformMover
{
    [Header("Rotation Settings")]
    [SerializeField] private float _rotationSpeed = 50f;
    [SerializeField] private Vector3 _rotationAxis = Vector3.up;
    
    private Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        Quaternion deltaRotation = Quaternion.Euler(_rotationAxis * (_rotationSpeed * Time.fixedDeltaTime));
        _rb.MoveRotation(_rb.rotation * deltaRotation);     
    }
}
