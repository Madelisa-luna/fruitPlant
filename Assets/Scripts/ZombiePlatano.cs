using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiePlatano : MonoBehaviour
{
    [SerializeField] private float vida;
    public Transform personaje;
    private NavMeshAgent agente;
    //private Animator anim;
    private BoxCollider2D colPlatano;
    private ConEnemigosPlatanos enemigos;

    private void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        //anim = GetComponentInChildren<Animator>();
        colPlatano = GetComponent<BoxCollider2D>();
        enemigos = FindObjectOfType<ConEnemigosPlatanos>();
    }
    private void Start()
    {
        agente.updateRotation = false;
        agente.updateUpAxis = false;
        personaje = GameObject.FindWithTag("personaje").transform;
    }
    private void Update()
    {
        agente.SetDestination(personaje.position);
        //anim.SetFloat("camina", 2);
    }

    public void RecibirDano(float dano)
    {
        vida -= dano;
        if (vida <= 0)
        {
            enemigos.EnemigoEliminado(1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("personaje"))
        {
            Personaje Per = collision.GetComponent<Personaje>();
            Per.CausarHerida();
        }
    }
}
