using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
   
    public float velocidad = 0f; //determina la velocidad con la que se mueve el fondo
    bool enMovimiento = false;  //determina si el personaje ha empezado a nadar
    private float tiempoInicio = 0f; //determina cuando empieza a moverse el scroll parallax


    void Start()
    {
        //observers en para recibir las notificaciones
        NotificationCenter.DefaultCenter().AddObserver(this, "pezNadando");
        NotificationCenter.DefaultCenter().AddObserver(this, "personajeMuerto");
        
            pezNadando(); //llamada al método "pezNadando"
        
    }

    /**
     * Método pezNadando.
     * cambia la variable bool enMovimiento a true (el pez se mueve)
     * el tiempo de inicio será el valor de Time.time
     */
    void pezNadando()
    {
        enMovimiento = true;
        tiempoInicio = Time.time;
    }

    /**
     * Método personajeMuerto.
     * cuando se recibe la notificación de que el personaje ha muerto,
     * en movimiento pasa a estado false
     */
    void personajeMuerto()
    {
        enMovimiento = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(enMovimiento) { //si en movimiento es verdadero...
            //obtenemos del Renderer el material y la textura principal, haciendo un nuevo Vector2 que va moviendose
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * velocidad, 0);
        }
       
    }
}
