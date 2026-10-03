using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    /**
     * Método OnTriggerEnter2D.
     * Recibe un collider2D donde, si es gameObject que colisiona tiene el tag "Player", se mandará una notificación de "personajeMuerto"
     * Si es cualquier otro, destruirá ese objeto.
     */
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player") {
            NotificationCenter.DefaultCenter().PostNotification(this, "personajeMuerto");
            other.gameObject.SetActive(false); //desactivamos el objeto que tiene este script (el pez)
        }
        else {
            Destroy(other.gameObject);
        }
    }
}
