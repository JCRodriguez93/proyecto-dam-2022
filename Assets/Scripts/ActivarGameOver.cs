using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarGameOver : MonoBehaviour
{
    
    public GameObject camaraGameOver; //referencia al objeto de la cámara gameover
    public AudioClip audiomuerte; //referencia al audioclip para el sonido de la muerte


    // Start is called before the first frame update
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "personajeMuerto"); //observer por si el personaje muere
        NotificationCenter.DefaultCenter().AddObserver(this, "pezMoribundo"); //observer por si el personaje está mal de vida

    }

    /**
     * Método "personajeMuerto".
     * Detiene el audio que está sonando en el objeto que tiene este script.
     * Asigna el nuevo audioclip (sonido muerte).
     * Asigna al nuevo audio el loop a falso (que no se repita).
     * La velocidad de la canción vuelve a 1
     * Hace sonar el nuevo audioclip y muestra la cámara de gameover.
     */
    void personajeMuerto(Notification notificacion)
    {
        this.GetComponent<AudioSource>().Stop();
        this.GetComponent<AudioSource>().clip = audiomuerte;
        this.GetComponent<AudioSource>().loop = false;
        this.GetComponent<AudioSource>().pitch = 1;
        this.GetComponent<AudioSource>().Play();
        camaraGameOver.SetActive(true);

    }


    /**
     * Método "pezMoribundo".
     * ralentiza el sonido principal.
     */
    void pezMoribundo(Notification notification) {

        this.GetComponent<AudioSource>().pitch = 0.80f;
    }
  
}
