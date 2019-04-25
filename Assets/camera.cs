using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject follow;
    public Vector2 mincampos,maxcampos;
    public float suavizado;
    private Vector2 velocity;

    void Start()
    {
    
    }
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x,
            follow.transform.position.x, ref velocity.x, suavizado);
        float posY = Mathf.SmoothDamp(transform.position.y,
            follow.transform.position.y, ref velocity.y, suavizado);

        transform.position = new Vector3(
            Mathf.Clamp(posX,mincampos.x,maxcampos.x),
            Mathf.Clamp(posY,mincampos.y,maxcampos.y),
            transform.position.z);
    }
}