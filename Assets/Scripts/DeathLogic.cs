using UnityEngine;

public class DeathLogic : MonoBehaviour
{
    [SerializeField] private Transform checkPoint;
    
    PlayerTeleporter boolCheck;
    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            boolCheck = player.GetComponent<PlayerTeleporter>();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (boolCheck != null)
            {
                if (boolCheck.firstLevelDone)
                {
                    Rigidbody rb = player.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.linearVelocity = Vector3.zero;
                        rb.angularVelocity = Vector3.zero;
                    }
                    player.transform.position = checkPoint.position;
                }
                else
                {
                    Destroy(collider.gameObject);
                    SceneHandler.instance.ReloadScene();       
                }
            }
        }
    }
}
