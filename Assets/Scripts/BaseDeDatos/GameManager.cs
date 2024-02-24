using UnityEngine;

using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

     // Variable estática para almacenar la única instancia de GameManager
    private static GameManager instance;

    public Text InfoText; // Referencia al objeto de texto en el que mostrarás la información

    // Propiedad estática para acceder a la instancia de GameManager
    public static GameManager Instance
    {
        get
        {
            // Si no hay una instancia existente, crear una nueva
            if (instance == null)
            {
                // Buscar un objeto GameManager en la escena
                instance = FindObjectOfType<GameManager>();

                // Si no se encuentra, crear un nuevo objeto GameManager en la escena
                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    public int vidaCargar = 100;
    public int puntosCargar = 0;
    public float posXCargar = -29f;
    public float posYCargar = -12.7f;
    public string emailUser1;


     // private GameObject newGamePanel;
    public GameObject loginPanelGraphic;
    public GameObject loadGamePanel;

    // Referencias a otras clases
    public Puntaje puntaje;
    public CombateJugador combateJugador;
    public PosicionJagu posicionJagu;

    public GameObject menuIniPartida;
    public GameObject DatosCargadosExitosamente;
    public TemporalStorage temporalStorage;
    // Referencia al DataManager
    public DataManager dataManager;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        puntaje = FindObjectOfType<Puntaje>();
        combateJugador = FindObjectOfType<CombateJugador>();
        posicionJagu = FindObjectOfType<PosicionJagu>();
        menuIniPartida = GameObject.Find("MenuIniPartida");
        dataManager = FindObjectOfType<DataManager>();
        if (dataManager == null)
        {
            Debug.LogError("No se encontró el DataManager en la escena.");
        }

        loadGamePanel = GameObject.Find("LoadGamePanel");
            
        DatosCargadosExitosamente = GameObject.Find("DatosCargadosExitosamente");
           
        




    }




   /* public void CargarDatosBD()
    {     ObtenerEmailUsuario1();
        if (dataManager != null)
        {
            dataManager.LoadData(emailUser1, (loadedUser) =>
            {
                if (loadedUser != null)
                {
                    Debug.Log("Usuario cargado desde BD GameManager: " + loadedUser.emailUser + ", Vida: " + loadedUser.vidaUser + ", Puntos: " + loadedUser.puntosUser + ", PosX: " + loadedUser.posNX + ", PosY: " + loadedUser.posNY);
                    vidaCargar = loadedUser.vidaUser;
                    puntosCargar = loadedUser.puntosUser;
                    posXCargar = loadedUser.posNX;
                    posYCargar = loadedUser.posNY;
                    
                    
                }
                else
                {
                    Debug.Log("No se encontraron datos para el usuario con ID: " + emailUser1);
                }
            });
        }
        else
        {
            Debug.LogError("DataManager no está inicializado correctamente.");
        }
    }*/

    public void CargarDatosPlayer()
    {
       int vidaCargar = PlayerPrefs.GetInt("VidaGuardar");
       int puntosCargar = PlayerPrefs.GetInt("PuntosGuardar");
       float posXCargar = PlayerPrefs.GetFloat("PosicionX");
       float posYCargar = PlayerPrefs.GetFloat("PosicionY");
        combateJugador.SetearVida(vidaCargar);
        puntaje.SetearPuntaje(puntosCargar);
        posicionJagu.SetPositionX(posXCargar);
        posicionJagu.SetPositionY(posYCargar);
         
    }


    public void PartidaCargada()
    {
        // Configura el mensaje con los datos cargados
        string mensaje = "Datos cargados:\n" +
                         "Vida: " + vidaCargar + "\n" +
                         "Puntos: " + puntosCargar + "\n" +
                         "Posición X: " + posXCargar + "\n" +
                         "Posición Y: " + posYCargar;
        
        // Actualiza el texto del objeto de texto con el mensaje
        InfoText.text = mensaje;

        Time.timeScale = 1f;
    

    }


      public void LoadPSiButtonClick()
    {         Time.timeScale = 0f;
        CargarDatosPlayer();
            PartidaCargada();
            DatosCargadosExitosamente.SetActive(true);
           
      

        
        Time.timeScale = 1f;
    }

    public void IniciarPartida(){
       
        DatosCargadosExitosamente.SetActive(false);
        loadGamePanel.SetActive(false);
            loginPanelGraphic.SetActive(false);



    }

}
