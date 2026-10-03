using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirPersonaje : MonoBehaviour
{
    public Transform pez; //componente Transform del personaje Pez
    public float separacion = 1f; //separación con respecto a la cámara

    /**
     * Método Update
     * crea un nuevo vector3 que añade al pez en la posición x (+la separación), y & z que le indiquemos
     */
    
    void Update()
    {
        transform.position = new Vector3(pez.position.x + separacion, transform.position.y,transform.position.z);
    }

    
}
