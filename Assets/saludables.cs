using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class saludables : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D colisionado)
    {
        if (colisionado.tag == "saludable")
        {
            Destroy(colisionado.gameObject);
        }
        if(colisionado.tag == "endmission")
        {
            cargarEscena("end");
        }

    }
    public void cargarEscena(string pNombreEscena)
    {
        SceneManager.LoadScene(pNombreEscena);
    }
}
