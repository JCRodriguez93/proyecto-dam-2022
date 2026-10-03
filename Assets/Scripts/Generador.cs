using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{

    public GameObject[] obj; //array de objetos a generar
    public float tiempoMin = 5f; //tiempo mínimo para generar los objetos
    public float tiempoMax = 7f; //tiempo máximo para generar los objetos
    bool muerto = false; //estado del personaje



    // Start is called before the first frame update
    void Start()
    {
        //observadores
        NotificationCenter.DefaultCenter().AddObserver(this, "personajeMuerto"); //observer por si el personaje muere
        NotificationCenter.DefaultCenter().AddObserver(this, "pezVivo"); //observer para cuando el personaje empiece a nadar

    }

    /**
     * Método "personajeMuerto".
     * pone la variable booleana "muerto" a true para detener el generador
     */
    void personajeMuerto(Notification not)
    {
        muerto = true;
    }

    /**
     * Método "pezNadando".
     * Si se notifica que el pez está nadando, llama al método "Generar()"
     */
    void pezVivo(Notification noti)
    {
        Generar();
    }

    /**
     *Método "Generar"
     * Si el personaje no está muerto, generará instancias de los objetos que le hayamos asignado.
     */
    void Generar()
    {
        if (!muerto)
        {
            Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
            Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
        }

    }
}
