using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usuario : MonoBehaviour {

    [System.Serializable]
    public class Usuario
    {
        public int id;
        public string nombres;
        public string apellidoMaterno;
        public string apellidoPaterno;
        public string username;
        public string password;
        public string salt;
        public string emailAddress;
    }

    [System.Serializable]
    public class Periodo
    {
        public int id;
        public string nombre;
    }


    [System.Serializable]
    public class Colegio
    {
        public int id;
        public string nombre;
    }

    [System.Serializable]
    public class Curso
    {
        public int id;
        public string nombre;
    }

    [System.Serializable]
    public class Sesion
    {
        public int id;
        public Usuario idUser;
    }

    [System.Serializable]
    public class Token
    {
        public string token;
    }

    [System.Serializable]
    public class FormaReim
    {
        public int id;
        public Usuario idUser;
        //public Actividad idActividad;
        //public Reim idReim;
        public Sesion idSesion;
        public int touchCantidad;
        public float touchTiempo;
        public int errores;
        public int erroresGen;
        public int aciertos;
        public int aciertosGen;
        public int finalizado;
        public int ayudas;
        public float duracion;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
