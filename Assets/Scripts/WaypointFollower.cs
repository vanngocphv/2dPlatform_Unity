using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] _waypoints;
    [SerializeField] private float _movingSpeed = 2f;

    private int currentWaypointIndex = 0;


    private void Update()
    {
        if (Vector2.Distance(_waypoints[currentWaypointIndex].transform.position, this.gameObject.transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= _waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        this.transform.position = Vector2.MoveTowards(this.transform.position, _waypoints[currentWaypointIndex].transform.position, Time.deltaTime * _movingSpeed);
    }



}
