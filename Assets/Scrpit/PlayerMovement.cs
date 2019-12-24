using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    public float dashSpeed = 2.0f;

    float horizontalMove = 0f;

    bool Jump = false;

    bool Dash = true;

    bool corroutineAllowed = true;
    bool NegMove = false;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
            animator.SetBool("Ground", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Dash = true;
        }
        else
        {
            Dash = false;
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        animator.SetBool("Dash", Dash);
    }

    public void OnLanding()
    {
        animator.SetBool("Ground", true);
    }

    void FixedUpdate()
    {
        // move our character
        if (Dash)
        {
            horizontalMove *= dashSpeed;
        }
        if (NegMove)
        {
            horizontalMove *= -1;
        }
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, Jump);
        Jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ghost"))
        {
            if (corroutineAllowed)
            {
                StartCoroutine(NegControl());
            }
            collision.gameObject.SetActive(false);
        }
    }

    IEnumerator NegControl()
    {
        corroutineAllowed = false;
        NegMove = true;
        yield return new WaitForSeconds(2f);
        NegMove = false;
        corroutineAllowed = true;
    }
}
