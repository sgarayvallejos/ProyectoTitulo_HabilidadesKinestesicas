using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public Rigidbody2D rBD;
    public float speed = 1f, jumpforce =15;

    public float radio = 0.2f;
    public LayerMask layersuelo;
    public Transform pie;
    public bool estaensuelo, der_bool = false, izq_bool = false, voltear_niño = true;
    SpriteRenderer niñorender;

    void Start()
    {
        rBD = GetComponent<Rigidbody2D>();
        niñorender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {        
        detectorsuelo();

        if (Input.GetKey(KeyCode.RightArrow) || der_bool)
        {
            der();
            voltearderecha();
           
        }
        if (Input.GetKey(KeyCode.LeftArrow) || izq_bool)
        {
            izq();
            voltearizquierda();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            salto();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || !der_bool && !izq_bool)
        {
            velocityxd();
        }
    }
    //________________
    public void dertrue()
    {
        der_bool = true;
    }
    public void derfale()
    {
        der_bool = false;
    }
    public void izqtrue()
    {
        izq_bool = true;
    }
    public void izqfale()
    {
        izq_bool = false;
    }



    //________
    public void voltearderecha()
    {
        niñorender.flipX=false;
    }
    public void voltearizquierda()
    {
        niñorender.flipX = true;
    }
    
    public void der()
    {
        rBD.velocity += new Vector2(1 * speed,0);
    }
    public void izq()
    {
        rBD.velocity -= new Vector2(1 * speed, 0);
    }
    public void velocityxd()
    {
        rBD.velocity= new Vector2(0,rBD.velocity.y);
    }
    public void detectorsuelo()
    {
        estaensuelo = Physics2D.OverlapCircle(pie.position, radio, layersuelo);
    }
    public void salto()
    {
        if (!estaensuelo)
            return;
        rBD.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }
}
