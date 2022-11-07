using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Argo : MonoBehaviour
{
    private float velocidadMovimiento = 5.0f;
    [SerializeField] public Transform jugador;
    [SerializeField] private float distancia;
    [SerializeField] States currentstate;
    private Collision2D colision;

    public Vector3 puntoinicial;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    enum States
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

        if(distancia < 8.5f)
        {
            if(currentstate == States.IDLE)
            {
                setCurrentState(States.ATTACK);
            }
        }

        if(currentstate == States.ATTACK)
        {
            Ataque();
        }

        if(currentstate == States.CORREWACHIN)
        {
            Huida();
        }
    }

    private void setCurrentState(States state)
    {
        currentstate = state;
    }

    private void Ataque()
    {
        transform.position = Vector2.MoveTowards(transform.position, jugador.position, velocidadMovimiento * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if(currentstate == States.ATTACK)
            {
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
    }
}
