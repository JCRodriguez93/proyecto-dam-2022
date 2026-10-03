using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medalla : MonoBehaviour
{

    public int puntosSumados = 5; //puntos que se sumarán al coger cada medalla
    public AudioClip sonidoItem; //audioclip para el sonido de coger la medalla
    public float volumenItem = 15f; //volumen del sonido
    // Start is called before the first frame update

    /**
     * Método OnTriggerEnter2D.
     * Si la colisión es con un objeto del tag "Player" , notificará que se deben incrementar ciertos puntos
     * sonará en la cámara un audio de recogida de medalla.
     * Una vez cogido el item, se destruye.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            NotificationCenter.DefaultCenter().PostNotification(this, "incrementarPuntos", puntosSumados);
            AudioSource.PlayClipAtPoint(sonidoItem, Camera.main.transform.position, volumenItem); 
            GetComponent<AudioSource>().Play(); 
        }
        
        Destroy(gameObject);
    }
}
