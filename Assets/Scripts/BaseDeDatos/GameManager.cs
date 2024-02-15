using UnityEngine;
using System.Collections;

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
       temporalStorage.SetearPlayerPrefs();
       menuIniPartida.SetActive(false);
        Time.timeScale = 1f;

     }

       public void CargarJuego(){
       Time.timeScale = 0f;
       VerificarIdExistente();
        // Utiliza una corrutina para esperar a que los datos se carguen completamente
        StartCoroutine(EsperarCargaDatos());
       
     
      
     }

 IEnumerator EsperarCargaDatos()
    {
        // Llama al método para cargar los datos de la base de datos
        CargarDatosBD();

        // Espera hasta que los datos se hayan cargado completamente
        while (!DatosCargadosCompletamente())
        {
            yield return null;

        }
        // setear player prefs
       temporalStorage.SetearPlayerPrefs();
        // Cuando los datos se hayan cargado completamente, continúa con el resto del código
        Time.timeScale = 1f;
        menuIniPartida.SetActive(false);
        
     
    }
    
 bool DatosCargadosCompletamente()
    {
        // Aquí debes verificar si todos los datos que necesitas están cargados completamente
        // Por ejemplo, podrías verificar si vidaCargar, puntosCargar, posXCargar y posYCargar
        // tienen valores válidos
        // Retorna true si los datos se han cargado completamente, de lo contrario, retorna false

        return vidaCargar != 0 && puntosCargar != 0 && posXCargar != 0 && posYCargar != 0;
    }

   
}

  
