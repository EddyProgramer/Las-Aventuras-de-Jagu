



using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

public class LoginPanel : MonoBehaviour
{
    private const string BASE_URL = "https://fir-unity-c9e15-default-rtdb.firebaseio.com/";
    private InputField emailInput;
    private InputField passwordInput;

    void Start()
    {
        // Buscar los InputFields por sus nombres
        emailInput = GameObject.Find("EmailInput").GetComponent<InputField>();
        passwordInput = GameObject.Find("PasswordInput").GetComponent<InputField>();

        // Verificar si se han asignado los InputFields
        if (emailInput == null || passwordInput == null)
        {
            Debug.LogError("No se han asignado los campos de entrada en login panel.");
        }

          // Verificar si se han asignado los InputFields
        if (emailInput != null || passwordInput != null)
        {
            Debug.Log("Inputs fields asignados en login panel.");
        }

    }

    public void SendNewLoginData()
    {
        string email = emailInput.text;
        string password = passwordInput.text;

        UserPass loginUser = new UserPass
        {
            emailUser = email,
            passwordUser = password
        };

        RestClient.Put<UserPass>(BASE_URL + "UserPass.json", loginUser).Then(response =>
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
    }
}







