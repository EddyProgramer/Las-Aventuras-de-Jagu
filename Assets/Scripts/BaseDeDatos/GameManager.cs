using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int vidaCargar;

    public int puntosCargar;

    public float posXCargar;
    public float posYCargar;
  public Vector2 posicionJugadorCargar;
  public string userId;

 // Referencias a otras clases
    public Puntaje puntaje;
    public CombateJugador combateJugador;

    public PosicionJagu posicionJagu;
    
  public GameObject menuIniPartida;
  public TemporalStorage temporalStorage;
  // Referencia al DataManager
    public DataManager dataManager;



    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
        userId=PlayerPrefs.GetString("userIdTemp");
       temporalStorage= FindObjectOfType<TemporalStorage>();
       combateJugador= FindObjectOfType<CombateJugador>();
       puntaje= FindObjectOfType<Puntaje>();
       posicionJagu= FindObjectOfType<PosicionJagu>();
      
         menuIniPartida = GameObject.Find("MenuIniPartida");
         // Obtener la instancia del DataManager
           dataManager= FindObjectOfType<DataManager>();
        dataManager = DataManager.instance;
     
       
       
        // Suscribirse al evento DataLoaded del DataManager
       /* if (dataManager != null)
        {
            dataManager.DataLoaded += OnDataLoaded;
     
            dataManager.LoadData(userId);
        }
        else
        {
            Debug.LogError("DataManager reference is null!");
        }*/
      
    }
    

   /* public void GuardarDatos()
    {
             
         
          ObtenerPlayerPrefs();

        PreviewLabs.PlayerPrefs.SetInt("VidaGuardar", vida);
        Debug.Log("vida cargada al playerprefs"+vida);
        PreviewLabs.PlayerPrefs.SetInt("PuntosGuardados", puntos);
        Debug.Log("puntos cargados al playerprefs"+puntos);
        PreviewLabs.PlayerPrefs.SetFloat("posicionX", posicionJugador.x);
        PlayerPrefs.SetFloat("posicionY", posicionJugador.y);
         Debug.Log("posicion Player cargado al playerprefs"+posicionJugador);
        PreviewLabs.PlayerPrefs.Flush();

      

    }*/

    

   /* public void ObtenerPlayerPrefs(){

 
          vida = PreviewLabs.PlayerPrefs.GetInt("VidaGuardada",88); // Valor por defecto de vida es 100 si no se encuentra guardado
         

           Debug.Log("vidaObtenida: " + vida);
           
         puntos = PreviewLabs.PlayerPrefs.GetInt("PuntosGuardados",17); // Valor por defecto de puntos es 0 si no se encuentra guardado
         
       
         Debug.Log("puntos obtenidos: " + puntos);
         posX = PreviewLabs.PlayerPrefs.GetFloat("posicionX",2.20f); // Valor por defecto de posición X es 0 si no se encuentra guardado

   
         Debug.Log("posX obtenida: " + posX);
        
         posY = PreviewLabs.PlayerPrefs.GetFloat("posicionY",2.02f); // Valor por defecto de posición Y es 0 si no se encuentra guardado

     Debug.Log("posY obtenida: " + posY);

      
      posicionJugador = new Vector2(posX, posY);



     }*/

      private void VerificarIdNuevoUsuario()
    {

         // Verificar si existe el userIdTemp en PlayerPrefs
    if (PlayerPrefs.HasKey("userIdTemp"))
    {
        string loadedUser = PlayerPrefs.GetString("userIdTemp");
        Debug.Log("Usuario encontrado en prefs GameManager: " + loadedUser);
        // mensaje para cargar datos
    }
    else
    {
        Debug.Log("No se encontró el usuario en PlayerPrefs. Generando nuevo userIdTemp...");
        // Si el usuario no existe, generar un nuevo userIdTemp
        temporalStorage.GenerarUserIdTemp();
    }
        
    }


    
         private void VerificarIdExistente()
    {

         // Verificar si existe el userIdTemp en PlayerPrefs
    if (PlayerPrefs.HasKey("userIdTemp"))
    {
        string loadedUser = PlayerPrefs.GetString("userIdTemp");
        Debug.Log("Usuario encontrado en prefs GameManager: " + loadedUser);
        // Llamada a funcion de carga de datos


    }
    else
    {
        Debug.Log("No se encontró el usuario en PlayerPrefs. Generando nuevo userIdTemp...");
        // Mensaje de iniciar nueva partida
        
    }
        
    }


    public void CargarDatosBD()
{
    DataManager.instance.LoadData(userId, usuario =>
    {
        if (usuario != null)
        {
            Debug.Log("Usuario cargado GameManager: " + usuario.id + ", Vida: " + usuario.vidaGuardar+ ", Puntos: " + usuario.puntosTotal+ ", PosX: " + usuario.posicionGX+ ", PosY: " + usuario.posicionGY);
            vidaCargar = usuario.vidaGuardar;
            puntosCargar = usuario.puntosTotal;
            posXCargar = usuario.posicionGX;
            posYCargar = usuario.posicionGY;
            
            // Una vez que los datos se han cargado completamente, cargar los datos del jugador
            CargarDatosPlayer();
        }
        else
        {
            Debug.Log("No se encontraron datos para el usuario con ID: " + userId);
        }
    });
}



    public void CargarDatosPlayer()
{
                combateJugador.SetearVida(vidaCargar);
                puntaje.SetearPuntaje(puntosCargar);
                posicionJagu.SetPositionX(posXCargar);
                 posicionJagu.SetPositionY(posYCargar);


}





     public void IniciarNuevoJuego(){
      
      
      VerificarIdNuevoUsuario();
     
       menuIniPartida.SetActive(false);
        Time.timeScale = 1f;

     }

       public void CargarJuego(){
       Time.timeScale = 0f;
       VerificarIdExistente();
       CargarDatosBD();
       Time.timeScale = 1f;
      menuIniPartida.SetActive(false);
      
     }
   
}

  
