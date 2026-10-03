using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    
    public AudioClip sonidoEnemigo; //audioclip para el sonido del golpe enemigo
    public float volumenMordida = 15f; //volumen del sonido


    /**
     * Método OnTriggerEnter2D
     * si la colisión se hace contra un collider2D con el tag "Player" mandará una notificación de bajarVida.
     * sonará un sonido en la cámara con respecto a el enemigo que golpee al personaje y posteriormente 
     * se destruirá el enemigo.
     */
    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player")
        {  
            NotificationCenter.DefaultCenter().PostNotification(this, "bajarVida");
            AudioSource.PlayClipAtPoint(sonidoEnemigo, Camera.main.transform.position, volumenMordida); 
            GetComponent<AudioSource>().Play();    
        }
        Destroy(gameObject);
    }  
}
