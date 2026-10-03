using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValoresGameOver : MonoBehaviour
{

    public TextMesh total; //variable para objeto TextMesh dedicado a los totales
    public TextMesh record; //variable para objeto TextMesh dedicado al record
    public Puntos puntos; //objeto de la clase Puntos para acceder a los miembros

    /**
     * Método onEnable.
     * Se activa cuando se mande una notificación de que el personaje a muerto.
     * Cuando se activa, actualiza la puntuación del jugador.
     */
    private void OnEnable()
    {
        total.text = puntos.puntuacion.ToString();
        record.text = Estado.estadoJuego.puntMx.ToString();
    }
}
