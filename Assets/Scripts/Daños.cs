using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daños : MonoBehaviour
{
    public BarraVida logicaBarraVida; //objeto de la clase BarraVida

    // Start is called before the first frame update
    void Start()
    {
        //se observa la notificación de bajar vida
        NotificationCenter.DefaultCenter().AddObserver(this, "bajarVida");
    }
   
    /**
     * Método onTriggerEnter2D.
     * si la colisión recibida es por un tiburón, se quita 70 de vida
     * si la colisión recibida es por una estrella, se quita 15 de vida
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tiburon")
        {
            logicaBarraVida.vidaActual -= 70f;
        }
        else if (collision.gameObject.tag == "Estrella")
        {
            logicaBarraVida.vidaActual -= 15f;
        }
    }

}
