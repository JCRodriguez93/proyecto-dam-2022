using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salir : MonoBehaviour
{


    private void OnMouseDown()
    {
        Exit();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
