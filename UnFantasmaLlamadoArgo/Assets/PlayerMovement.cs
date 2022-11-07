using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] States currentstate;
    enum States
    {
        IDLE,
        MOVEMENT,
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float drx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(drx * 7, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10);
        }

        if (drx != 0)
        {
            setCurrentState(States.MOVEMENT);
        }
        else
        {
            setCurrentState(States.IDLE);
        }
    }

    private void setCurrentState(States state)
    {
        currentstate = state;
    }
}
