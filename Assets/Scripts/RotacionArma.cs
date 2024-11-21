using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionArma : MonoBehaviour
{
    private Vector3 objetivo;
    private SpriteRenderer spriteArma;
    public Transform arma;
    private void Start()
    {
        arma = GameObject.FindWithTag("arma").transform;
    }
    private void Awake()
    {
        spriteArma = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        objetivo = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var anguloGrados = Mathf.Atan2(objetivo.y, objetivo.x) * Mathf.Rad2Deg;
        anguloGrados += 180;
        arma.rotation = Quaternion.Euler(new Vector3(0, 0, anguloGrados));
        if (anguloGrados > 90 && anguloGrados < 270) 
        { 
            spriteArma.flipY = true; 
        }
        else
        {
            spriteArma.flipY = false;
        }
    }
}