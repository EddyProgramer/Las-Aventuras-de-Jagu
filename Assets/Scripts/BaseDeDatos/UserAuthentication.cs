using System;
using UnityEngine;
using UnityEngine.UI;

public class UserAuthentication : MonoBehaviour
{
    private const string VIDA_GUARDAR_KEY = "VidaGuardar";
    private const string PUNTOS_GUARDAR_KEY = "PuntosGuardar";
    private const string POSICION_X_KEY = "PosicionX";
    private const string POSICION_Y_KEY = "PosicionY";

    [SerializeField] private string dataManagerName;
    [SerializeField] private string gameManagerName;
    [SerializeField] private LoginPanel loginPanel;
    [SerializeField] private GameObject datosCargadosExitosamente;

    private InputField emailInput;
    private InputField passwordInput;
    private GameObject newGamePanel;
    private GameObject loadGamePanel;
    private GameObject loginPanelGraphic;
    private DataManager dataManager;
    private GameManager gameManager;

    private void Start()
    {
        dataManager = GameObject.Find(dataManagerName)?.GetComponent<DataManager>();
        if (dataManager == null)
            Debug.LogError("No se encontró el objeto DataManager con el nombre: " + dataManagerName);

        gameManager = GameObject.Find(gameManagerName)?.GetComponent<GameManager>();
        if (gameManager == null)
            Debug.LogError("No se encontró el objeto GameManager con el nombre: " + gameManagerName);

        newGamePanel = GameObject.Find("NewGamePanel");
        loadGamePanel = GameObject.Find("LoadGamePanel");
        loginPanelGraphic = GameObject.Find("LoginPanel");

        SetPanelActive(newGamePanel, false);
        SetPanelActive(loadGamePanel, false);
        SetPanelActive(loginPanelGraphic, true);

        Button enviarDatosButton = GameObject.Find("EnviarDatos").GetComponent<Button>();
        if (enviarDatosButton != null)
            enviarDatosButton.onClick.AddListener(OnEnviarDatosButtonClick);
        else
            Debug.LogError("No se ha encontrado el botón 'EnviarDatos'.");

        emailInput = GameObject.Find("EmailInput").GetComponent<InputField>();
        passwordInput = GameObject.Find("PasswordInput").GetComponent<InputField>();

        if (emailInput == null || passwordInput == null)
            Debug.LogError("No se han asignado los campos de entrada en User Authentication.");
    }

    public void AuthenticateUser()
    {
        string emailUser = emailInput.text;
        string passwordUser = passwordInput.text;

        dataManager.LoadData(emailUser, (loadedUser) =>
        {
            if (loadedUser != null && loadedUser.passwordUser == passwordUser)
            {
                Debug.Log("¡Autenticación exitosa!");
                PlayerPrefs.SetInt(VIDA_GUARDAR_KEY, loadedUser.vidaUser);
                PlayerPrefs.SetInt(PUNTOS_GUARDAR_KEY, loadedUser.puntosUser);
                PlayerPrefs.SetFloat(POSICION_X_KEY, loadedUser.posNX);
                PlayerPrefs.SetFloat(POSICION_Y_KEY, loadedUser.posNY);
                loadGamePanel.SetActive(true);
            }
            else
            {
                HandleAuthenticationFailure();
            }
        });
    }

    private void HandleAuthenticationFailure()
    {
        Debug.LogError("Falló la autenticación.");
        SetPanelActive(newGamePanel, true);
        SetPanelActive(loadGamePanel, false);
    }

    private void OnEnviarDatosButtonClick()
    {
        AuthenticateUser();
    }

    private void SetPanelActive(GameObject panel, bool active)
    {
        if (panel != null)
            panel.SetActive(active);
        else
            Debug.LogError("No se ha encontrado el panel.");
    }

    public void OnpartidaSiButtonClick()
    {
        if (loginPanel != null)
            loginPanel.SendNewLoginData();
        SetPanelActive(newGamePanel, false);
        SetPanelActive(loginPanelGraphic, false);
        Time.timeScale = 1f;
    }

    public void OnpartidaNoButtonClick()
    {
        SetPanelActive(newGamePanel, false);
    }

  
    public void LoadPNoButtonClick()
    {
        SetPanelActive(loadGamePanel, false);
    }

    [Serializable]
    public class UserPass
    {
        public string emailUser;
        public string passwordUser;
    }
}





/*using UnityEngine;
//using Proyecto26;
using UnityEngine.UI;
using System.Collections;

public class UserAuthentication : MonoBehaviour
{
    //private const string BASE_URL = "https://fir-unity-c9e15-default-rtdb.firebaseio.com/";

    public string dataManager1;
      public string userManager1;
    public string gameManager1;
    public LoginPanel loginPanel;

    private InputField emailInput;
    private InputField passwordInput;
    private GameObject newGamePanel;
    private GameObject loginPanelGraphic;
    private GameObject loadGamePanel;

    private DataManager dataManager;
    private GameManager gameManager;
       

    void Start()
    {

       
        dataManager = GameObject.Find(dataManager1)?.GetComponent<DataManager>();
        if (dataManager == null)
            Debug.LogError("No se encontró el objeto DataManager con el nombre: " + dataManager1);

        gameManager = GameObject.Find(gameManager1)?.GetComponent<GameManager>();
        if (gameManager == null)
            Debug.LogError("No se encontró el objeto GameManager con el nombre: " + gameManager1);

        newGamePanel = GameObject.Find("NewGamePanel");
        loadGamePanel = GameObject.Find("LoadGamePanel");
        loginPanelGraphic = GameObject.Find("LoginPanel");

        SetPanelActive(newGamePanel, false);
        SetPanelActive(loadGamePanel, false);
        SetPanelActive(loginPanelGraphic, true);

        Button enviarDatosButton = GameObject.Find("EnviarDatos").GetComponent<Button>();
        if (enviarDatosButton != null)
            enviarDatosButton.onClick.AddListener(OnEnviarDatosButtonClick);
        else
            Debug.LogError("No se ha encontrado el botón 'EnviarDatos'.");

        emailInput = GameObject.Find("EmailInput").GetComponent<InputField>();
        passwordInput = GameObject.Find("PasswordInput").GetComponent<InputField>();

        if (emailInput == null || passwordInput == null)
            Debug.LogError("No se han asignado los campos de entrada en User Authentication.");
    }

    public void AuthenticateUser()
    {
        string emailUser = emailInput.text;
        string passwordUser = passwordInput.text;

        dataManager.LoadData(emailUser, (loadedUser) =>
        {
            if (loadedUser != null && loadedUser.passwordUser == passwordUser)
            {
                Debug.Log("¡Autenticación exitosa!");
                
                loadGamePanel.SetActive(true);
            }
            else
            {
                HandleAuthenticationFailure();
            }
        });
    }
// En UserAuthentication.cs
public void ObtenerCorreoElectronico() {
    // Suponiendo que obtienes el correo electrónico de algún campo de entrada de texto llamado "campoCorreo"
    string correoElectronico = emailInput.text;

    // Llama al método en GameManager para establecer el correo electrónico
    gameManager.SetEmailUser(correoElectronico);
   // userManager1.SetEmailUser(correoElectronico);
    
}
   

    void HandleAuthenticationFailure()
    {
        Debug.LogError("Falló la autenticación.");
        SetPanelActive(newGamePanel, true);
        SetPanelActive(loadGamePanel, false);
    }

    void OnEnviarDatosButtonClick()
    {
        AuthenticateUser();
         ObtenerCorreoElectronico();
    }

    void SetPanelActive(GameObject panel, bool active)
    {
        if (panel != null)
            panel.SetActive(active);
        else
            Debug.LogError("No se ha encontrado el panel.");
    }

    public void OnpartidaSiButtonClick()
    {
        if (loginPanel != null)
            loginPanel.SendNewLoginData();
        SetPanelActive(newGamePanel, false);
        SetPanelActive(loginPanelGraphic, false);
        Time.timeScale = 1f;
    }

    public void OnpartidaNoButtonClick()
    {
        SetPanelActive(newGamePanel, false);
    }

    public void LoadPSiButtonClick()
    {
        // Establecer Time.timeScale en 1 antes de iniciar la corutina
          Time.timeScale = 1f;
        if (loginPanel != null)
        {
            StartCoroutine(LoadDataCoroutine());
        }

        SetPanelActive(newGamePanel, false);
        SetPanelActive(loginPanelGraphic, false);
        //Time.timeScale = 1f;
    }

    private IEnumerator LoadDataCoroutine()
    {
        // Llama a CargarDatosBD()
        GameManager.Instance.CargarDatosBD();

        // Espera durante 0.1 segundos
        //yield return new WaitForSeconds(4f);
        //yield return new WaitForEndOfFrame();
        yield return new WaitForSecondsRealtime(3f);
          Debug.Log("Espera completada"); 

        // Continúa con el resto del código después de la espera
        // Por ejemplo, podrías mostrar un panel o hacer cualquier otra cosa aquí
    }
    
        
       
       
       
       
        /*if (loginPanel != null)
      GameManager.Instance.CargarDatosBD();
        SetPanelActive(newGamePanel, false);
        SetPanelActive(loginPanelGraphic, false);
        Time.timeScale = 1f;*/
    

   /* public void LoadPNoButtonClick()
    {
        SetPanelActive(loadGamePanel, false);
    }

    [System.Serializable]
    public class UserPass
    {
        public string emailUser;
        public string passwordUser;
    }
}*/

