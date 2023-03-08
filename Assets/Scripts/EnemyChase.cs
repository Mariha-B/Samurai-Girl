using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    [SerializeField] private float speed = 2f;
    private void Update()
    {
        if(isChasing)
        {
            if(transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if(transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position += Vector3.right * speed * Time.deltaTime;
            }

        }
        else
        {

            if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)

            {
                isChasing = true;
            }

            if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) <.1f)
            {
            currentWaypointIndex++;
                if(currentWaypointIndex >= waypoints.Length)
                {
                currentWaypointIndex = 0;

                }
            }
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
    }




      
}
