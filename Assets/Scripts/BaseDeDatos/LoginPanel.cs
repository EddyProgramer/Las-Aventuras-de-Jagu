

using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

public class LoginPanel : MonoBehaviour
{
    private const string BASE_URL = "https://fir-unity-c9e15-default-rtdb.firebaseio.com/";

    private InputField emailInput;
    private InputField passwordInput;

    public    int puntosUserNew1 = 0;
    public    int vidaUserNew1 = 100;
   public     float posicionNX1 = -36;
   public     float posicionNY1 = 17;

    void Start()
    {
        emailInput = GameObject.Find("EmailInput").GetComponent<InputField>();
        passwordInput = GameObject.Find("PasswordInput").GetComponent<InputField>();

        if (emailInput == null || passwordInput == null)
        {
            Debug.LogError("No se han asignado los campos de entrada en login panel.");
        }
    }

    public void SendNewLoginData()
    {   
        PrefsNuevoJuego();
        string email = emailInput.text;
        string password = passwordInput.text;
        int puntosUserNew = 0;
        int vidaUserNew = 100;
        float posicionNX = -36;
        float posicionNY = 17;

        UserPass loginUser = new UserPass
        {
            emailUser = email,
            passwordUser = password,
            puntosUser = puntosUserNew,
            vidaUser = vidaUserNew,
            posNX = posicionNX,
            posNY = posicionNY
        };

        RestClient.Put<UserPass>(BASE_URL + "Users/" + email.Replace(".", "_") + ".json", loginUser).Then(response =>
        {
            Debug.Log("Login data sent successfully!");
        }).Catch(err =>
        {
            Debug.LogError("Error sending login data: " + err.Message);
        });
    }




    [System.Serializable]
    public class UserPass
    {
        public string emailUser;
        public string passwordUser;
        public int puntosUser;
        public int vidaUser;
        public float posNX;
        public float posNY;
        
    }

    public void PrefsNuevoJuego(){
         PlayerPrefs.SetString("EmailGuardar",emailInput.text);
   PlayerPrefs.SetString("PasswordGuardar",passwordInput.text);
       PlayerPrefs.SetInt("VidaGuardar",vidaUserNew1);
  PlayerPrefs.SetInt("PuntosGuardar",puntosUserNew1);
 PlayerPrefs.SetFloat("PosicionX",posicionNX1 );
  PlayerPrefs.SetFloat("PosicionY",posicionNY1);
 Debug.Log("Variables Login Panel: " +emailInput.text+ " " + passwordInput.text );


    }
}




