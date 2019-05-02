using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tramp : MonoBehaviour
{
    public static bool trampa = false;
    public GameObject trmpa;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D colisionado)
    {
        trampactive(colisionado);
    }


    public void trampactive(Collider2D colisionado)
    {
        if (colisionado.tag == "trampa")
        {   
            cayoenlatrampa();
        }
    }

    public void cayoenlatrampa()
    {
        trmpa.SetActive(true);
        Time.timeScale = 0f;
        trampa = true;
    }

}

    
