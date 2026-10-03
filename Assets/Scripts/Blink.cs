using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    // Start is called before the first frame update
    public Material original, blink; //referencias al material original y al blink

    /**
     * Método onTriggerEnter2D.
     * si el objeto con este script recibe una colisión por un tiburón o estrella.
     * realizará un parpadeo momentaneo.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tiburon" || collision.tag == "Estrella") {

            StartCoroutine(DamagesSerios()); //llamada a la co-rutina.
        }
    }

    /***
     * Método IEnumerator DamagesSerios.
     * obtiene del componente el material y lo cambia a blanco.
     * con una espera de 0.3f segundos, vuelve a ponerlo a original.
     */
    IEnumerator DamagesSerios() {      
            GetComponent<SpriteRenderer>().material = GetComponent<Blink>().blink;
            yield return new WaitForSeconds(0.3f);
            GetComponent<SpriteRenderer>().material = GetComponent<Blink>().original;

    }
}
