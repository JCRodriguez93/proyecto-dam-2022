using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntos : MonoBehaviour
{
    public int puntuacion = 0; //puntos con los que el jugador empieza la partida
    public TextMesh marcador; //objeto TextMesh para mostrar la puntuación

    // Start is called before the first frame update
    void Start()
    {
        //observadores, incrementarPuntos y personajeMuerto
        NotificationCenter.DefaultCenter().AddObserver(this, "incrementarPuntos");
        NotificationCenter.DefaultCenter().AddObserver(this, "personajeMuerto");
        actualizarPuntos(); //llamada al método actualizarPuntos

    }

    /**
     * Método personajeMuerto.
     * recibe por parámetro la notificación de que el personaje ha fallecido.
     */
    void personajeMuerto(Notification not) {
        //si la puntuación es mayor que la puntuación guardada en Estado como puntuación máxima...
    if (puntuacion > Estado.estadoJuego.puntMx)
        { //actualiza y guarda en dichas variables la puntuación.
            Estado.estadoJuego.puntMx = puntuacion;
            Estado.estadoJuego.guardar();
        }
    
    }
    /**
     * Método incrementarPuntos.
     * recibe notificaciones para ir incrementando los puntos obtenidos.
     */
    void incrementarPuntos(Notification not) {
        //se realiza un casteo de los datos recibidos de la notificacion y se le asigna a sumar
        int sumar = (int) not.data;
        puntuacion += sumar; //se le añadirán dichos puntos a la variable puntuación
        actualizarPuntos(); //llamada al método actualizarPuntos
    }
    /**
     * Método actualizarPuntos.
     * al objeto TextMesh se le añaden los valores de la puntuación.
     */
    void actualizarPuntos()
    {
        marcador.text = "puntos: "+puntuacion.ToString();

    }
   
}
