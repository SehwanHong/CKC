using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyPatrol : MonoBehaviour
{
    public float EnemySpeed = 40f;

    public Transform[] moveSpots;

    private int randomSpot;

    private float stayTime;
    public float startWaitTime;

    void Start()
    {
        stayTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, EnemySpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (stayTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                stayTime = startWaitTime;
            }   else
            {
                stayTime -= Time.deltaTime;
            }
        }
    }
}
