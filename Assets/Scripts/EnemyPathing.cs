using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        // if not yet reached last waypoint then..
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            // MoveTowrds target
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            // checked to see if reached.
            if (transform.position == targetPosition)
            {
                // if so, increment target waypoint
                waypointIndex++;
            }

        }
        // else destroy
        else
        {
            Destroy(gameObject);
        }
    }
}
