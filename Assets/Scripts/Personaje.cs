using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personaje : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private CapsuleCollider2D coliderP;
    [SerializeField] UI UIManager;

    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spritePersonaje;
    private double posColx1 = -2.5;
    private double posColy1 = -0.3;
    private int vidaPersonaje = 5;

    private void Awake()
    {
        rig = GetComponentInChildren<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spritePersonaje = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    anim.SetTrigger("Ataca");
        //}
        if (Input.GetKeyDown(KeyCode.K))
        {
            CausarHerida();
        }
    }


    private void FixedUpdate()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rig.velocity = new Vector2(horizontal, vertical) * velocidad;
        anim.SetFloat("camina", Mathf.Abs(rig.velocity.magnitude));

        if (horizontal > 0)
        {
            float posColx = (float)posColx1;
            float posColy = (float)posColy1;
            coliderP.offset = new Vector2(-1, posColy);
            spritePersonaje.flipX = true;
        }
        else if (horizontal < 0)
        {
            float posColx = (float)posColx1;
            float posColy = (float)posColy1;
            coliderP.offset = new Vector2(posColx, posColy);
            spritePersonaje.flipX = false;
        }

    }

    public void CausarHerida()
    {
        if (vidaPersonaje > 0)
        {
            vidaPersonaje--;
            UIManager.RestaCorazones(vidaPersonaje);
            if (vidaPersonaje == 0)
            {
                Debug.Log("Hemos muerto");
            }
        }
    }
}
