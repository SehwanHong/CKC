using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinpatrol : MonoBehaviour
{
    public float speed = 10f;
    public GameObject right;
    public GameObject left;
    private bool moveright = true;


    private void Update()
    {
        if (Mathf.Abs(transform.position.x - right.transform.position.x) < 0.2f && right.activeSelf == true)
        {
            moveright = false;
            right.SetActive(false);
            left.SetActive(true);
        }
        if (Mathf.Abs(transform.position.x - left.transform.position.x) < 0.2f && left.activeSelf == true)
        {
            moveright = true;
            left.SetActive(false);
            right.SetActive(true);
        }


        if (moveright)
        {
            transform.position = Vector2.MoveTowards(transform.position, right.transform.position, speed * Time.deltaTime);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, left.transform.position, speed * Time.deltaTime);
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
