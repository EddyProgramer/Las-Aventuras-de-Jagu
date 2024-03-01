using System;
using UnityEngine;
using UnityEngine.UI;

public class UserAuthentication : MonoBehaviour
{
    private const string EMAIL_GUARDAR_KEY = "EmailGuardar";
    private const string PASSWORD_GUARDAR_KEY = "PasswordGuardar";
    private const string VIDA_GUARDAR_KEY = "VidaGuardar";
    private const string PUNTOS_GUARDAR_KEY = "PuntosGuardar";
    private const string POSICION_X_KEY = "PosicionX";
    private const string POSICION_Y_KEY = "PosicionY";
      

    [SerializeField] private string dataManagerName;
    [SerializeField] private string gameManagerName;
    [SerializeField] private LoginPanel loginPanel;
    [SerializeField] private GameObject datosCargadosExitosamente;
    [SerializeField] private GameObject panelEspera;
        [SerializeField] private GameObject panelEsperaExitosa;
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
        panelEspera = GameObject.Find("PanelEspera");
        panelEsperaExitosa = GameObject.Find("PanelEsperaExitosa");
        SetPanelActive(loginPanelGraphic, true);
        SetPanelActive(newGamePanel, false);
        SetPanelActive(loadGamePanel, false);
        SetPanelActive(panelEspera, false);
        SetPanelActive(panelEsperaExitosa, false);

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
        string emailUser1 = emailInput.text;
        string passwordUser = passwordInput.text;

  

        dataManager.LoadData(emailUser1, (loadedUser) =>


        {

           
            if (loadedUser != null && loadedUser.passwordUser == passwordUser)
            {
            
             
                Debug.Log("¡Autenticación exitosa!");
                PlayerPrefs.SetString(EMAIL_GUARDAR_KEY, loadedUser.emailUser);
                PlayerPrefs.SetString(PASSWORD_GUARDAR_KEY, loadedUser.passwordUser);
                PlayerPrefs.SetInt(VIDA_GUARDAR_KEY, loadedUser.vidaUser);
                PlayerPrefs.SetInt(PUNTOS_GUARDAR_KEY, loadedUser.puntosUser);
                PlayerPrefs.SetFloat(POSICION_X_KEY, loadedUser.posNX);
                PlayerPrefs.SetFloat(POSICION_Y_KEY, loadedUser.posNY);
                CheckPlayerPrefs();
                loadGamePanel.SetActive(true);
                panelEspera.SetActive(false);
                panelEsperaExitosa.SetActive(true);
                  
            }
            else
            {
                HandleAuthenticationFailure();
            }
        });
    }

    private void HandleAuthenticationFailure()
    {GameObject panelEspera = GameObject.Find("PanelEspera");
        Debug.LogError("Falló la autenticación.");
           
            SetPanelActive(panelEspera, false);
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


    

    // metodo para chequear seteo de player prefs

      private void CheckPlayerPrefs()
    {
        if (PlayerPrefs.HasKey(EMAIL_GUARDAR_KEY) && PlayerPrefs.HasKey(PASSWORD_GUARDAR_KEY) &&PlayerPrefs.HasKey(VIDA_GUARDAR_KEY) &&
            PlayerPrefs.HasKey(PUNTOS_GUARDAR_KEY) && PlayerPrefs.HasKey(POSICION_X_KEY) &&
            PlayerPrefs.HasKey(POSICION_Y_KEY))
        {
            Debug.Log("¡PlayerPrefs establecidos correctamente!");
            // Aquí podrías realizar alguna acción adicional si las PlayerPrefs están establecidas.
        }
        else
        {
            Debug.Log("¡PlayerPrefs no están establecidos correctamente!");
            // Aquí podrías manejar el caso en que las PlayerPrefs no estén establecidas.
        }
    }

    [Serializable]
    public class UserPass
    {
        public string emailUser;
        public string passwordUser;
    }

    public void EsperaExitosaAceptar(){
      
       panelEsperaExitosa.SetActive(false);


    }
}





