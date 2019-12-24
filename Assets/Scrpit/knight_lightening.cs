using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight_lightening : MonoBehaviour
{
    public GameObject lightening;
    public GameObject lightening1;
    public GameObject lightening2;
    public GameObject lightening3;

    private Transform target;
    private float stayTime;
    public float maxpauseTime = 1.0f;
    public float minpauseTime = 0.5f;
    private float pauseTime;
    public float maxrunTime = 2.5f;
    public float minrunTime = 1.5f;
    private float runTime;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        lightening.SetActive(false);
        lightening1.SetActive(false);
        lightening2.SetActive(false);
        lightening3.SetActive(false);
        runTime = Random.Range(minrunTime, maxrunTime);
        pauseTime = Random.Range(minpauseTime, maxpauseTime);
        stayTime = runTime + pauseTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) < 10.0f)
        {
            //Debug.Log(stayTime);
            if (stayTime >= runTime)
            {
                lightening.SetActive(false);
                lightening1.SetActive(false);
                lightening2.SetActive(false);
                lightening3.SetActive(false);
                stayTime -= Time.deltaTime;
            }
            else if (0 <= stayTime && stayTime <= runTime)
            {
                lightening.SetActive(true);
                lightening1.SetActive(true);
                lightening2.SetActive(true);
                lightening3.SetActive(true);
                stayTime -= Time.deltaTime;
            }
            else if (stayTime <= 0)
            {
                runTime = Random.Range(minrunTime, maxrunTime);
                pauseTime = Random.Range(minpauseTime, maxpauseTime);
                stayTime = runTime + pauseTime;
            }
        }
        else
        {
            lightening.SetActive(false);
            lightening1.SetActive(false);
            lightening2.SetActive(false);
            lightening3.SetActive(false);
            runTime = Random.Range(minrunTime, maxrunTime);
            pauseTime = Random.Range(minpauseTime, maxpauseTime);
            stayTime = runTime + pauseTime;
        }
    }
}
