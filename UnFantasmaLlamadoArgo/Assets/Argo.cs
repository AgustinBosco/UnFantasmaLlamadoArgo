using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Argo : MonoBehaviour
{
    private float velocidadMovimiento = 5.0f;
    [SerializeField] public Transform jugador;
    [SerializeField] private float distancia;
    [SerializeField] public States currentstate;
    public int puntaje;
    public Animator animator;
    private Collision2D colision;

    public Vector3 puntoinicial;

    private SpriteRenderer spriteRenderer;

    public enum States
    {
        IDLE,
        ATTACK,
        CORREWACHIN
    }

    private void Start()
    {
        setCurrentState(States.IDLE);
        puntoinicial = transform.position;
    }

    private void Update()
    {
        distancia = Vector2.Distance(transform.position, jugador.position);

        FSM();
    }

    private void setCurrentState(States state)
    {
        if (currentstate != state)
        {
            currentstate = state;
        }
    }

    private void Ataque()
    {
        transform.position = Vector2.MoveTowards(transform.position, jugador.position, velocidadMovimiento * Time.deltaTime);
        animator.SetFloat("Movement", 1.0f);
        animator.SetFloat("Huida", 0.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if(currentstate == States.ATTACK)
            {
                puntaje++;
                setCurrentState(States.CORREWACHIN);
            }
            else
            {
                setCurrentState(States.ATTACK);
            }
            Debug.Log(currentstate);
        }
    }

    private void Huida()
    {
        Vector2 dir = transform.position - jugador.position;
        transform.Translate(dir * Time.deltaTime);
        animator.SetFloat("Movement", 0.0f);
        animator.SetFloat("Huida", 1.0f);
    }

    public void FSM()
    {
        switch (currentstate)
        {
            case States.IDLE:
                if (distancia < 8.5f)
                {
                    setCurrentState(States.ATTACK);
                }
                break;
            case States.ATTACK:
                Ataque();
                break;
            case States.CORREWACHIN:
                Huida();
                break;
        }
    }
}
