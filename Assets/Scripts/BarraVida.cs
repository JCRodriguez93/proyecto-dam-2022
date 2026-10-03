using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//importante
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{

    public int vidaMax; //vida máxima del objeto (Pez)
    public float vidaActual; //vida actual del pez
    public Image barradeVida; //imagen de la barra de vida


    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMax; //la vida actual debe ser la misma que la vida máxima
        //observer bajarVida
        NotificationCenter.DefaultCenter().AddObserver(this, "bajarVida"); 
    }



    // Update is called once per frame
    void Update()
    {
        revisar_vida(); //llamamos al método para ir revisando cuanto nos queda de vida


        if (vidaActual > 80)
        { //si el personaje está vivo...

            NotificationCenter.DefaultCenter().PostNotification(this, "pezNadando");
        }
        else if (vidaActual < 20 && vidaActual > 1) {
            //si el personaje está cerca de morir....
            NotificationCenter.DefaultCenter().PostNotification(this, "pezNadando");
            NotificationCenter.DefaultCenter().PostNotification(this, "pezMoribundo");

        }

        else if (vidaActual <= 0)
        { //si la vida es 0...
            NotificationCenter.DefaultCenter().PostNotification(this, "personajeMuerto");

            gameObject.SetActive(false); //desactivamos el objeto que tiene este script (el pez)
        }
        
    }


    /**
     * método revisar vida.
     * a la barra le quitamos el "fillAmount" para que sea la vida actual dividido de la vida máxima
     * En resumen, siempre está revisando cuanto nos queda de vida.
     */
    public void revisar_vida() {

        barradeVida.fillAmount = vidaActual / vidaMax;
        
    }

   
}
