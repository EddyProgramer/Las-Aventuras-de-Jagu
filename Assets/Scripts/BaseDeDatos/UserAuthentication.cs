




using UnityEngine;
using Proyecto26;
using Newtonsoft.Json;
using UnityEngine.UI;


public class UserAuthentication : MonoBehaviour
{
    private const string BASE_URL = "https://fir-unity-c9e15-default-rtdb.firebaseio.com/";
    private InputField emailInput;
    private InputField passwordInput;
    public LoginPanel loginPanel;
    public GameObject gameManager;
    
  private GameObject newGamePanel; // Variable para almacenar la referencia al panel NewGamePanel
 private GameObject loginPanelGrafic; 
    void Start()
    { // Buscar el panel NewGamePanel 
         gameManager = GameObject.Find("GameManager");
        if (gameManager == null)
        {
            Debug.LogError("No se ha encontrado el game manager.");
        }
        else
        {
            // Desactivar el panel para que no sea visible pero siga activo en la escena
            Debug.Log(" se ha encontrado el game manager.");
        }
        
        newGamePanel = GameObject.Find("NewGamePanel");
        if (newGamePanel == null)
        {
            Debug.LogError("No se ha encontrado el panel NewGamePanel.");
        }
        else
        {
            // Desactivar el panel para que no sea visible pero siga activo en la escena
            newGamePanel.SetActive(false);
        }
        loginPanelGrafic = GameObject.Find("LoginPanel");
        if (loginPanelGrafic == null)
        {
            Debug.LogError("No se ha encontrado el panel Login Panel.");
        }
        else
        {
            // Desactivar el panel para que no sea visible pero siga activo en la escena
            newGamePanel.SetActive(false);
        }
      
         // Buscar los botones por su nombre
    Button enviarDatosButton = GameObject.Find("EnviarDatos").GetComponent<Button>();



        // Verificar si se ha encontrado el botón
        if (enviarDatosButton == null)
        {
            Debug.LogError("No se ha encontrado algun boton'.");
        }
        else
        {
            // Agregar un listener para el evento de clic
            
            enviarDatosButton.onClick.AddListener(OnEnviarDatosButtonClick);
           
        }

        // Buscar los InputFields por sus nombres
        emailInput = GameObject.Find("EmailInput").GetComponent<InputField>();
        passwordInput = GameObject.Find("PasswordInput").GetComponent<InputField>();
         loginPanel = GameObject.Find("LoginPanel").GetComponent<LoginPanel>();

        // Verificar si se han asignado los InputFields
        if (emailInput == null || passwordInput == null)
        {
            Debug.LogError("No se han asignado los campos de entrada en User Autentication.");
        }
    }

    public void AuthenticateUser(string email, string password)
    {
        string emailUser = emailInput.text;
        string passwordUser = passwordInput.text;
     

           UserPass loginUser = new UserPass
        {
            emailUser = email,
            passwordUser = password
        };
        RestClient.Get(BASE_URL + "UserPass.json").Then(response =>
        {
            if (!string.IsNullOrEmpty(response.Text))
            {
                UserPass user = JsonConvert.DeserializeObject<UserPass>(response.Text);

                if (user.emailUser == email && user.passwordUser == password)
                {
                    Debug.Log("Authentication successful!");
                    // Aquí puedes realizar acciones adicionales, como cargar la escena principal, mostrar un mensaje de éxito, etc.


                }
                else
                {
                    Debug.LogError("Authentication failed. Invalid email or password.");

                    newGamePanel.SetActive(true);
                 
                }
            }
            else
            {
                Debug.LogError("No data retrieved from the server.");
            }
        }).Catch(err =>
        {
            Debug.LogError("Error authenticating user: " + err.Message);
        });
    }

    void OnEnviarDatosButtonClick()
    {
        // Llama a tu método AuthenticateUser aquí, utilizando los valores de los campos de entrada
        AuthenticateUser(emailInput.text, passwordInput.text);
    }

 

       public  void OnpartidaSiButtonClick()
    {    
          loginPanel.SendNewLoginData();
          newGamePanel.SetActive(false);
          loginPanelGrafic.SetActive(false);
    }
         public   void OnpartidaNoButtonClick()
    {
        newGamePanel.SetActive(false);
    }

    [System.Serializable]
    public class UserPass
    {
        public string emailUser;
        public string passwordUser;
    }
}











/*using UnityEngine;
using Proyecto26;
using Newtonsoft.Json;
using UnityEngine.UI;


public class UserAuthentication : MonoBehaviour
{
    private const string BASE_URL = "https://fir-unity-c9e15-default-rtdb.firebaseio.com/";
    private InputField emailInput;
    private InputField passwordInput;
    public LoginPanel loginPanel;
    
  private GameObject newGamePanel; // Variable para almacenar la referencia al panel NewGamePanel

    void Start()
    { // Buscar el panel NewGamePanel por su etiqueta
        newGamePanel = GameObject.Find("NewGamePanel");
        if (newGamePanel == null)
        {
            Debug.LogError("No se ha encontrado el panel NewGamePanel.");
        }
        else
        {
            // Desactivar el panel para que no sea visible pero siga activo en la escena
            newGamePanel.SetActive(false);
        }

      

         // Buscar el botón por su nombre
    Button enviarDatosButton = GameObject.Find("EnviarDatos").GetComponent<Button>();
//Button partidaSiButton = GameObject.Find("ButtonSi").GetComponent<Button>();
//Button partidaNoButton = GameObject.Find("ButtonNO").GetComponent<Button>();

        // Verificar si se ha encontrado el botón
        if (enviarDatosButton == null)
        {
            Debug.LogError("No se ha encontrado algun boton'.");
        }
        else
        {
            // Agregar un listener para el evento de clic
            
            enviarDatosButton.onClick.AddListener(OnEnviarDatosButtonClick);
           
        }

        // Buscar los InputFields por sus nombres
        emailInput = GameObject.Find("EmailInput").GetComponent<InputField>();
        passwordInput = GameObject.Find("PasswordInput").GetComponent<InputField>();
         loginPanel = GameObject.Find("LoginPanel").GetComponent<LoginPanel>();

        // Verificar si se han asignado los InputFields
        if (emailInput == null || passwordInput == null)
        {
            Debug.LogError("No se han asignado los campos de entrada en User Autentication.");
        }
    }

    public void AuthenticateUser(string email, string password)
    {
        string emailUser = emailInput.text;
        string passwordUser = passwordInput.text;
     

           UserPass loginUser = new UserPass
        {
            emailUser = email,
            passwordUser = password
        };
        RestClient.Get(BASE_URL + "UserPass.json").Then(response =>
        {
            if (!string.IsNullOrEmpty(response.Text))
            {
                UserPass user = JsonConvert.DeserializeObject<UserPass>(response.Text);

                if (user.emailUser == email && user.passwordUser == password)
                {
                    Debug.Log("Authentication successful!");
                    // Aquí puedes realizar acciones adicionales, como cargar la escena principal, mostrar un mensaje de éxito, etc.


                }
                else
                {
                    Debug.LogError("Authentication failed. Invalid email or password.");

                    newGamePanel.SetActive(true);
                    loginPanel.SendNewLoginData();
                }
            }
            else
            {
                Debug.LogError("No data retrieved from the server.");
            }
        }).Catch(err =>
        {
            Debug.LogError("Error authenticating user: " + err.Message);
        });
    }

    void OnEnviarDatosButtonClick()
    {
        // Llama a tu método AuthenticateUser aquí, utilizando los valores de los campos de entrada
        AuthenticateUser(emailInput.text, passwordInput.text);
    }

 

         void OnpartidaSiButtonClick()
    {
        // Llama a tu método AuthenticateUser aquí, utilizando los valores de los campos de entrada
        AuthenticateUser(emailInput.text, passwordInput.text);
    }
             void OnpartidaNoButtonClick()
    {
        // Llama a tu método AuthenticateUser aquí, utilizando los valores de los campos de entrada
        AuthenticateUser(emailInput.text, passwordInput.text);
    }

    [System.Serializable]
    public class UserPass
    {
        public string emailUser;
        public string passwordUser;
    }
}*/












