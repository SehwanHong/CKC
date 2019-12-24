using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_arrow : MonoBehaviour
{
    [SerializeField]
    GameObject Arrow;

    public float fireRate = 5f;
    private float nextFire;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        nextFire = fireRate;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        nextFire -= Time.deltaTime;
        if (nextFire <= 0
            && Vector2.Distance(target.position, transform.position) <= 15f
            && target.position.x <= transform.position.x - 6f)
        {
            Vector3 arrow = new Vector3(transform.position.x - 0.027f, transform.position.y + .525f, 0f);
            Vector3 trueposition = arrow - target.position;
            Instantiate(Arrow, arrow, Quaternion.Euler(0,0, Mathf.Atan(trueposition.y/trueposition.x)*Mathf.Rad2Deg));
            nextFire = fireRate;
        }
    }

    
}
