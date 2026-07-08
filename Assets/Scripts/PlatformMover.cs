using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] Transform[] waypoints;
    [SerializeField] float maxDistance = 2f;
    #endregion

    #region Private Fields
    private Vector3[] _waypointPositions;
    private int _currentWaypointIndex;
    private float _radius = 0.05f;
    private Vector3 _velocity = Vector3.zero;
    private float _smoothingTime = 0.8f;
    #endregion
    
    private void Start()
    {
        _waypointPositions = new Vector3[waypoints.Length];
        for (int i = 0; i < waypoints.Length; i++)
        {
            _waypointPositions[i] = waypoints[i].position;
        }
    }

    private void FixedUpdate()
    {
        if (waypoints.Length == 0) return;
        
        transform.position = Vector3.SmoothDamp(
            transform.position, 
            _waypointPositions[_currentWaypointIndex], 
            ref _velocity, 
            _smoothingTime);

        if (Vector3.Distance(transform.position, _waypointPositions[_currentWaypointIndex]) < _radius)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypointPositions.Length;
        }
        
        
    }
}
