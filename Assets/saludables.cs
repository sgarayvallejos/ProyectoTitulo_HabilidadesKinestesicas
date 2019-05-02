using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class saludables : MonoBehaviour
{
    private GameObject healthbar;

    void Start()
    {
        healthbar = GameObject.Find("barra");
    }

    public void OnTriggerEnter2D(Collider2D colisionado)
    {
        comidasaludable(colisionado);
        comidanosaludable(colisionado);

        if(colisionado.tag == "endmission")
        {
            cargarEscena("end");
        }

    }
    public void cargarEscena(string pNombreEscena)
    {
        SceneManager.LoadScene(pNombreEscena);
    }

    public void comidasaludable(Collider2D colisionado)
    {
        if (colisionado.tag == "saludable")
        {
            Destroy(colisionado.gameObject);
            healthbar.SendMessage("voidTakeBadAliment",-10);
        }
    }
    public void comidanosaludable(Collider2D colisionado)
    {
        if (colisionado.tag == "nosaludable")
        {
            Destroy(colisionado.gameObject);
            healthbar.SendMessage("voidTakeBadAliment",10);
        }
    }
}
