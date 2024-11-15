using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    //El siguiente codigo ayuda a cambiar de escena habilitando un
    //item y eliminando cierta cantidad de enemigos para pasar de nivel

    [SerializeField] private int cantidadEnemigos;
    [SerializeField] private int enemigosEliminados;

    //Varible con referencia a la animación
    private Animator animator; 

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        cantidadEnemigos = GameObject.FindGameObjectsWithTag("Enemigos").Length;
        
    }

    private void ActivarBandera()
    {
        animator.SetTrigger("Activar");
    }

    public void EnemigoEliminado()
    {
        enemigosEliminados += 1;
        if (enemigosEliminados == cantidadEnemigos)
        {
            ActivarBandera();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && enemigosEliminados == cantidadEnemigos)
        {
            //Cambiar de escena
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
