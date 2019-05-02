using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loginD : usuario , IPointerDownHandler {

    public GameObject username;//datos ing 245102739
    public GameObject password;//Datos ing 2451
    public string Usuario;//boton unity
    public string Contraseña;//boton unity 
    private static string BaseUrl = "http://ulearnet.org:8080/";
    public static string token = "Bearer eyJhbGciOiJIUzUxMiJ9.eyJpYXQiOjE1NTQ5NTYwNzYsInN1YiI6InJlaW11bGVhcm5ldCIsImV4cCI6MTU1NTgyMDA3Nn0.rya-VNQDm_zJ9vT34J2IOF2TEYBxo5dedtlCotxoi7yrLfFsOnCqyNvRAjS75ZKCVwrEgGcclpIzbR8Ur-DkwA";
    public static int idUsuario = 0;
    public string Escena;

    public IEnumerator autenticar()
    {
        if (Usuario.Trim() != "" && Contraseña.Trim() != "")
        {

            // nav.general.BaseUrl = "http://ulearnet.org:8080/";
            string url = BaseUrl + "login";
            // Headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/x-www-form-urlencoded");
            //Form
            WWWForm form = new WWWForm();
            form.AddField("username", Usuario);
            form.AddField("password", Contraseña);
            byte[] rawData = form.data;
            // Request
            WWW www = new WWW(url, rawData, headers);


            yield return www;
            Debug.Log(www.text);
            Debug.Log(www.responseHeaders);

            // si no hay conexion
            if (www.responseHeaders == null)
            {
                Debug.Log("No se estableció la conexión");
                //mensajePopUp("No se estableció conexión");
            }
            else if (www.responseHeaders.Count > 0)
            {

                foreach (KeyValuePair<string, string> entry in www.responseHeaders)
                {
                    if (entry.Value.Contains("200 OK"))
                    {
                        Debug.Log("Dentro de 200 CE");
                        Token token = JsonUtility.FromJson<Token>(www.text);
                        Token = token.token;
                        Debug.Log(Token);
                        url = BaseUrl + "usuario/username";
                        headers.Add("Authorization", Token);
                        www = new WWW(url, rawData, headers);
                        yield return www;

                        Usuario usuario = JsonUtility.FromJson<Usuario>(www.text);
                        idUsuario = usuario.id;
                        Debug.Log("Bienvenid@!\n " + usuario.nombres + " " + usuario.apellidoPaterno);
                        //mensajeUsuarioPopUp("Bienvenid@!\n " + usuario.nombres + " " + usuario.apellidoPaterno);

                        
                        
                            SceneManager.LoadScene(Escena);
                        



                        break;
                    }
                    else if (entry.Value.Contains("403 Forbidden"))
                    {
                        Debug.Log("Dentro de 400");
                        Debug.Log("Usuario y/o contraseña incorrectas");
                        //mensajePopUp("Usuario y/o contraseña incorrectas");
                    }
                    else if (entry.Value.Contains("404 Not Found"))
                    {
                        Debug.Log("Dentro de 404");
                        Debug.Log("No se encontró el acceso");
                        //mensajePopUp("No se encontró el acceso");
                    }
                }
            }
        }
        else
        {
            Debug.Log("Debe completar los campos");
            //mensajePopUp("Debe completar los campos");
        }
    }
    public string Token
    {
        get
        {
            return token;
        }

        set
        {
            token = value;
        }
    }

    public void BotonLogin()
    {
        //Debug.Log("11111111111111");
        
        StartCoroutine(autenticar());
    }
       
        // Update is called once per frame
        void Update () {
        
        Usuario = username.GetComponent<InputField>().text;
        Contraseña= password.GetComponent<InputField>().text;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("se ha tocado el boton");
        StartCoroutine(autenticar());
    }

}
