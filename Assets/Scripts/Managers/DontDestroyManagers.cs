using UnityEngine;

public class DontDestroyManagers : MonoBehaviour
{
    private static DontDestroyManagers _instance;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
