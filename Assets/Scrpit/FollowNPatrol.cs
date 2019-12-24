using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowNPatrol : MonoBehaviour
{

    public float speed = 5f;
    public float distance = 15f;
    public Transform Target;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        Target = GameObject.FindWithTag("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Target.position, transform.position) < distance)
        {   
            transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
        }
    }
}
