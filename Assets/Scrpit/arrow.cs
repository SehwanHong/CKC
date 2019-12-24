using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public float moveSpeed = 7f;

    private Vector3 dest;

    // Start is called before the first frame update
    void Start()
    {
        dest = GameObject.FindGameObjectWithTag("Player").transform.position;
        dest.x -= Mathf.Cos(Mathf.Deg2Rad*transform.eulerAngles.z)*10;
        dest.y -= Mathf.Sin(Mathf.Deg2Rad*transform.eulerAngles.z)*10;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dest, moveSpeed * Time.deltaTime);
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
