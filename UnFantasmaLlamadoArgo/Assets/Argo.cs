using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Argo : MonoBehaviour
{
    private float velocidadMovimiento = 5.0f;
    [SerializeField] public Transform jugador;
    [SerializeField] private float distancia;
    [SerializeField] public States currentstate;
    private NavMeshAgent navMeshAgent;
    public int puntaje = 1;
    public int argoPuntaje;
    public Animator animator;
    private Collision2D colision;
    public Text timerText;
    private float starttime;
    private bool timestart = false;
    public float t;

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
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    private void Update()
    {
        distancia = Vector2.Distance(transform.position, jugador.position);
        FSM();
        if (timestart)
        {
            t = Time.time - starttime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            timerText.text = minutes + ":" + seconds;
        }
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
        navMeshAgent.SetDestination(jugador.position);
        //transform.position = Vector2.MoveTowards(transform.position, jugador.position, velocidadMovimiento * Time.deltaTime);
        animator.SetFloat("Movement", 1.0f);
        animator.SetFloat("Huida", 0.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if(currentstate == States.ATTACK)
            {
                argoPuntaje++;
                setCurrentState(States.CORREWACHIN);
            }
            else
            {
                puntaje++;
                setCurrentState(States.ATTACK);
            }
            Debug.Log(currentstate);
        }
    }

    private void Huida()
    {

        Vector2 dir = transform.position - jugador.position;
        navMeshAgent.SetDestination(dir);
        //transform.Translate(dir * Time.deltaTime);
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
                    starttime = Time.time;
                    timestart = true;
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
