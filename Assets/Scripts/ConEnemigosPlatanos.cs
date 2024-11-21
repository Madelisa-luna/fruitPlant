using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConEnemigosPlatanos : MonoBehaviour
{
    private float minX, minY, maxX, maxY;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private Object[] enemigos;
    [SerializeField] private float tiempoEnemigos;
    [SerializeField] private int numEnemigos;
    private float tiempoSiguenteEnemigo;
    private int Eliminados;

    private void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);
        Eliminados = 0;
    }

    private void Update()
    {
        if (Eliminados <= numEnemigos)
        {
            tiempoSiguenteEnemigo += Time.deltaTime;
            if (tiempoSiguenteEnemigo >= tiempoEnemigos)
            {
                tiempoSiguenteEnemigo = 0;
                //crear enemigo
                crearEnemigo();
            }
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void crearEnemigo()
    {
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(enemigos[numeroEnemigo], posicionAleatoria, Quaternion.identity);
    }

    public void EnemigoEliminado(int num)
    {
        Eliminados += num;
        //Debug.Log(Eliminados);
    }
}
