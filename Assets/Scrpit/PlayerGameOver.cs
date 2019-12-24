using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGameOver : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject PlayerGraphic;
    public GameObject NextLevel;

    public int playerHealth = 9;

    public Image[] hearts;

    int playerLayer, EnemyLayer;

    bool coroutineAllowed = true;

    Color color;

    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        GameOver.SetActive(false);
        NextLevel.SetActive(false);
        playerLayer = this.gameObject.layer;
        EnemyLayer = LayerMask.NameToLayer("Enemy");
        Physics2D.IgnoreLayerCollision(playerLayer, EnemyLayer, false);

        rend = PlayerGraphic.GetComponent<Renderer>();
        color = rend.material.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            playerHealth -= 1;
            if (coroutineAllowed)
            {
                StartCoroutine(Immortal());
            }

            gameOverSign();
            displayHealth();
        }
        if (collision.gameObject.tag.Equals("Lava"))
        {
            playerHealth = 0;
            gameOverSign();
            displayHealth();
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Finish"))
        {
            Debug.Log("collided with finish pol");
            NextLevel.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void gameOverSign()
    {
        if (playerHealth < 1)
        {
            GameOver.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void displayHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }


    IEnumerator Immortal()
    {
        coroutineAllowed = false;
        Physics2D.IgnoreLayerCollision(playerLayer, EnemyLayer, true);
        color.a = 0.5f;
        rend.material.color = color;
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(playerLayer, EnemyLayer, false);
        color.a = 1f;
        rend.material.color = color;
        coroutineAllowed = true;

    }
}
