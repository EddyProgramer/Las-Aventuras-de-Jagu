using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    public int vidaCargar;

    public int puntosCargar;

    public float posXCargar;
    public float posYCargar;
  public Vector2 posicionJugadorCargar;
  //public string userId;
public  string userId ;
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
        
       // userId=PlayerPrefs.GetString("userIdTemp");
       temporalStorage= FindObjectOfType<TemporalStorage>();
       combateJugador= FindObjectOfType<CombateJugador>();
       puntaje= FindObjectOfType<Puntaje>();
       posicionJagu= FindObjectOfType<PosicionJagu>();
      
         menuIniPartida = GameObject.Find("MenuIniPartida");
         // Obtener la instancia del DataManager
           dataManager= FindObjectOfType<DataManager>();
        dataManager = DataManager.instance;
     
       
       
       
    }
    


private void VerificarStatusUsuario(){


      // Intentar cargar el UUID existente desde PlayerPrefs
        string playerUUID = PlayerPrefs.GetString(userId);
// Si no hay un UUID almacenado, generarlo y guardarlo
        if (string.IsNullOrEmpty(playerUUID))
        {
            playerUUID = GenerarUserIdTemp();
            PlayerPrefs.SetString(userId, playerUUID);
            PlayerPrefs.Save();
        
            
        }
           else
           {
              StartCoroutine(EsperarCargaDatos());

            
           }

        // Utilizar el UUID cargado o generado
        Debug.Log("UUID del jugador: " + playerUUID);
      
   





}

private string  GenerarUserIdTemp()
    {
       

return Guid.NewGuid().ToString();

    }





    /*  private void VerificarIdNuevoUsuario()
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
       // temporalStorage.GenerarUserIdTemp();
    }
        
    }*/


    
        /* private void VerificarIdExistente()
    {

         // Verificar si existe el userIdTemp en PlayerPrefs
    if (PlayerPrefs.HasKey("userIdTemp"))
    {
        string loadedUser = PlayerPrefs.GetString("userIdTemp");
        Debug.Log("Usuario encontrado en prefs GameManager: " + loadedUser);
        // Llamada a funcion de carga de datos
        StartCoroutine(EsperarCargaDatos());

    }
    else
    {
        Debug.Log("No se encontró el usuario en PlayerPrefs. Generando nuevo userIdTemp...");
        // Mensaje de iniciar nueva partida
        
    }
        
    }*/


    public void CargarDatosBD()
{
    DataManager.instance.LoadData(userId, usuario =>
    {
        if (usuario != null)
        {
            Debug.Log("Usuario cargado desde BD GameManager: " + usuario.id + ", Vida: " + usuario.vidaGuardar+ ", Puntos: " + usuario.puntosTotal+ ", PosX: " + usuario.posicionGX+ ", PosY: " + usuario.posicionGY);
            vidaCargar = usuario.vidaGuardar;
            puntosCargar = usuario.puntosTotal;
            posXCargar = usuario.posicionGX;
            posYCargar = usuario.posicionGY;
            
            // Una vez que los datos se han cargado completamente, cargar los datos del jugador
            CargarPrefsCargarPartida();
            CargarDatosPlayer();
          
        }
        else
        {
            Debug.Log("No se encontraron datos para el usuario con ID: " + userId);
        }
    });
}



   public void CargarPrefsCargarPartida(){
       


     
    
       PreviewLabs.PlayerPrefs.SetInt("VidaGuardar", vidaCargar);
        Debug.Log("vida cargada al playerprefs"+vidaCargar);
        PreviewLabs.PlayerPrefs.SetInt("PuntosGuardar", puntosCargar);
        Debug.Log("puntos cargados al playerprefs"+puntosCargar);
        PreviewLabs.PlayerPrefs.SetFloat("PosicionX", posXCargar);
         Debug.Log("posicion X cargado playerprefs"+posXCargar);
        PlayerPrefs.SetFloat("posicionY", posXCargar);
         PreviewLabs.PlayerPrefs.SetFloat("PosicionY", posYCargar);
         Debug.Log("posicion Y cargado playerprefs"+posYCargar);
        PreviewLabs.PlayerPrefs.Flush();










   }

    public void CargarDatosPlayer()

           
{

               PreviewLabs.PlayerPrefs.GetInt("VidaGuardar", vidaCargar);
              PreviewLabs.PlayerPrefs.GetInt("PuntosGuardar", puntosCargar);
               PreviewLabs.PlayerPrefs.GetFloat("PosicionX", posXCargar);
                PreviewLabs.PlayerPrefs.GetFloat("PosicionY", posXCargar);
                combateJugador.SetearVida(vidaCargar);
                puntaje.SetearPuntaje(puntosCargar);
                posicionJagu.SetPositionX(posXCargar);
                 posicionJagu.SetPositionY(posYCargar);


}





     public void IniciarNuevoJuego(){
      
      VerificarStatusUsuario();
     // VerificarIdNuevoUsuario();
      // temporalStorage.SetearPlayerPrefs();
       menuIniPartida.SetActive(false);
        Time.timeScale = 1f;

     }

       public void CargarJuego(){

        VerificarStatusUsuario();
       //Time.timeScale = 0f;
       //VerificarIdExistente();
     
       
     
      
     }


     public void BorrarPlayerPrefs(){
         // Borrar una clave específica de PlayerPrefs
     string vidaBorrar = "VidaGuardar";
     PlayerPrefs.DeleteKey(vidaBorrar); 
       string puntosBorrar = "PuntosGuardar";
     PlayerPrefs.DeleteKey(puntosBorrar); 
       string posXBorrar = "PosicionX";
     PlayerPrefs.DeleteKey(posXBorrar); 
     string posYBorrar = "PosicionY";
     PlayerPrefs.DeleteKey(posYBorrar); 




     }

 IEnumerator EsperarCargaDatos()
    {

        BorrarPlayerPrefs();
         Debug.Log("Player prefs borrados en game manager");
         
        // Llama al método para cargar los datos de la base de datos
        CargarDatosBD();

        // Espera hasta que los datos se hayan cargado completamente
        while (!DatosCargadosCompletamente())
        {
            yield return null;

        }
      
      

       //temporalStorage.SetearPlayerPrefs();
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

  
