using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    [SerializeField] Transform teleportPoint;

    Rigidbody _rb;

    public bool firstLevelDone{ get; private set; }

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        ScoreManager.OnScoreAchieved += TeleportPlayer;
    }

    void OnDisable()
    {
        ScoreManager.OnScoreAchieved -= TeleportPlayer;
    }

    void TeleportPlayer()
    {
        if (firstLevelDone) return;
        
        if (firstLevelDone == false)
        {
            firstLevelDone = true;
            _rb.linearVelocity = Vector3.zero;   
            transform.position = teleportPoint.position; 
        }
        
    }
}
