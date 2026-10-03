using System; //para String y [Serializable]
using System.IO; //para el uso de entradas y salidas en archivos
using UnityEngine;

public class Estado : MonoBehaviour
{
    public int puntMx = 0; //variable que guarda los puntos máximos
    public static Estado estadoJuego; //variable que guarda el estado del juego (autoreferencia)
    private String rutaRegistros; //ruta donde se almacenarán los registros de la puntuación


    /**  ___________________________________________________________________________
     * |                                                                            |
     * | Este método es compartido por un objeto de la primera escena y la segunda  |
     * | Al no destruir el objeto podemos acceder a los valores de script y poder   |
     * | utilizarlos en la siguiente escena. Lo llevan en la escena A y B           |
     * |____________________________________________________________________________|
     */

    // Start is called before the first frame update
    void Start()
    {
        //cargamos la partida en el inicio
        cargar();

    }


    /**
     * Metodo Awake.
     * Similar al método Start para inicializar el componente, solo que está se ejecuta antes.
     * Aquí se guarda la ruta de los registros en un fichero .json
     * Si no hay nada
     */
    private void Awake()
    {
        rutaRegistros = Application.persistentDataPath+"/registro.json"; //ruta donde se van a guardar los registros
        if(estadoJuego == null) { //si estado juego es null...

            estadoJuego = this; //nos referenciamos a nosotros mismos
            DontDestroyOnLoad(gameObject); //objeto que queremos que no se destruya en el cambio de escenas

        }else if (estadoJuego != this) //si el estado de juego es distinto a la instancia actual
            Destroy(gameObject); //nos destruimos, para no tener dos objetos en la siguiente escena

        }



    /**
     * Método Cargar.
     * Si el archivo a cargar existe en la ruta, se lee su contenido JSON y se
     * deserializa con JsonUtility (compatible con IL2CPP/WebGL/móvil).
     */
    void cargar() {
        if (File.Exists(rutaRegistros)) //si existe...
        {
            try
            {
                string json = File.ReadAllText(rutaRegistros); //leo el contenido del fichero
                DatosGuardados datos = JsonUtility.FromJson<DatosGuardados>(json); //deserializo los datos
                puntMx = (datos != null) ? datos.puntuacionMax : 0; //los datos de la puntuación máxima serán los guardados en "datos"
            }
            catch (Exception e)
            {
                Debug.LogWarning("No se pudo cargar el registro de puntuación: " + e.Message);
                puntMx = 0; //si el fichero está corrupto empezamos de cero
            }

        }else { //en caso contrario...
            puntMx = 0; //la puntuación máxima será 0
                }


    }
   public void guardar() {

        DatosGuardados datos = new DatosGuardados(); //objeto de la clase serializada
        datos.puntuacionMax = puntMx; //accedemos a la puntuación máxima guardada y la igualamos a la obtenida
        File.WriteAllText(rutaRegistros, JsonUtility.ToJson(datos)); //serializamos los datos a JSON
    }


    /**
     * Clase DatosGuardados.
     * Esta clase lo que hace es tener un entero con la puntuación máxima.
     * Tendrá la característica de ser serializable, por lo tanto los puntos
     * se guardarán en un fichero.
     */
    [Serializable]
    class DatosGuardados
    {
        public int puntuacionMax;


    }
}
