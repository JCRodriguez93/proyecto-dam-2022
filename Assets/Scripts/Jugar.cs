using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugar : MonoBehaviour
{
   
    /**
     * Método OnMouseDown.
     * Al pulsar sobre el botón, accedemos al audio de la cámara y lo detenemos. posteriormente accedemos al AudioSource del propio botón
     * y hacemos que suene. Se llama al método Invoke que hará que la escena tarde tanto en cargarse como el tamaño de lo que suene.
     */
    private void OnMouseDown()
    {
      
        //accedo al audio de la cámara para detenerlo al pulsar "jugar"
        Camera.main.GetComponent<AudioSource>().Stop();
        //inicio el audio del botón play al pulsar "jugar"
        this.GetComponent<AudioSource>().Play();
      
        //al pulsar en "Jugar" abre la siguiente escena
        Invoke("CargarNivelJuego", this.GetComponent<AudioSource>().clip.length);
    }

    /**
     * Método CargarNivelJuego.
     * Carga la siguiente escena del juego.
     */
    void CargarNivelJuego()
    {
        SceneManager.LoadScene("GameScene");
    }
}
