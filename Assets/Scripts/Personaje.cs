using UnityEngine;

public class Personaje : MonoBehaviour
{


    public float fuerzaImpulso = 0f; //valor de la fuerza de impulso del pez
    public float velocidadNadando = 0f; //valor de la velocidad a la que el pez nada
    private bool nadando = false; //valor de si el pez está o no nadando
    private float yAnterior; //valor de la "Y" anterior



    /**
     * método FixedUpdate.
     * Si el personaje está nadando...
     */
    private void FixedUpdate()
    {
        if (nadando)
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(velocidadNadando, GetComponent<Rigidbody2D>().linearVelocity.y);

        }
    }


    // Update is called once per frame
    void Update()
    {
        //subir al pez la velocidad
        velocidadNadando = velocidadNadando + 0.0005f;

        if (Input.touchSupported && Input.touchCount > 0)
        {
            /**
             * CÓDIGO TÁCTIL.
             * En móvil/tablet la pantalla se divide en dos mitades:
             * tocando la mitad superior el pez sube y tocando la mitad inferior baja.
             * Así los controles funcionan sin necesidad de botones en pantalla.
             */
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch toque = Input.GetTouch(i);
                if (toque.phase == TouchPhase.Began) //solo al empezar el toque, no mientras se mantiene
                {
                    if (toque.position.y < Screen.height * 0.5f)
                        Impulsar(Vector2.down); //mitad inferior: bajar
                    else
                        Impulsar(Vector2.up); //mitad superior: subir
                }
            }
        }
        else
        {
            /**
             * CÓDIGO PARA ratón (escritorio).
             * Botón izquierdo para subir y botón derecho para bajar.
             */
            if (Input.GetMouseButtonDown(0)) //si el botón izquierdo es presionado
            {
                Impulsar(Vector2.up); //Impulsar al Pez hacia arriba
            }

            if (Input.GetMouseButtonDown(1)) //si el botón derecho es presionado
            {
                Impulsar(Vector2.down); //Impulsar al Pez hacia abajo
            }
        }

        yAnterior = transform.position.y; //yAnterior obtendrá el valor del componente transform, posición "y" actual.

    }

    /**
     * Método Impulsar.
     * Activa el nado la primera vez y aplica una fuerza en la dirección indicada.
     */
    private void Impulsar(Vector2 direccion)
    {
        if (!nadando) //si el pez no está nadando
        {
            nadando = true; //la variable "nadando" será verdadera (empieza a nadar)
            NotificationCenter.DefaultCenter().PostNotification(this, "pezVivo"); //se notifica a todos que el pez está nadando
        }
        GetComponent<Rigidbody2D>().AddForce(direccion * fuerzaImpulso); //impulsar al Pez
    }
}
