using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float dano;

    private void Update()
    {
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemigoFresa"))
        {
            ZombieFresa enemigo = collision.GetComponent<ZombieFresa>();
            if (enemigo != null)
            {
                enemigo.RecibirDano(dano);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("El objeto colisionado no tiene el componente ZombieFresa");
            }
        }
        else if (collision.CompareTag("enemigoPlatano"))
        {
            ZombiePlatano enemigo = collision.GetComponent<ZombiePlatano>();
            if (enemigo != null)
            {
                enemigo.RecibirDano(dano);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("El objeto colisionado no tiene el componente ZombieFresa");
            }
        }
        else if (collision.CompareTag("enemigoManzana"))
        {
            ZombieManzana enemigo = collision.GetComponent<ZombieManzana>();
            if (enemigo != null)
            {
                enemigo.RecibirDano(dano);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("El objeto colisionado no tiene el componente ZombieFresa");
            }
        }
    }

}
