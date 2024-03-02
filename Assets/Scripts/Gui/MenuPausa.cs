

using UnityEngine;
using Proyecto26;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

  private const string BASE_URL = "https://fir-unity-c9e15-default-rtdb.firebaseio.com/"; // URL base de Firebase
 

      public string emailJaguPrefs;
      public string passwordJaguPrefs;
       public int vidaJaguPrefs;
       public int puntosJaguPrefs;
       public float posXJaguPrefs;
        public float posYJaguPrefs;

   
      
    public DataManager dataManager;
    public TemporalStorage temporalStorage;
     //private GameManager gameManager;

    [SerializeField] private GameObject botonPausa;

    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject panelGuardadoExitoso;

     public CombateJugador combateJugador;
    public Puntaje puntaje;
   
     public PosicionJagu posicionJagu;

         void Start()
    {
        panelGuardadoExitoso = GameObject.Find("PanelGuardadoExitoso");
        
        panelGuardadoExitoso.SetActive(false);
      
    }
   public void Pausa(){
    Time.timeScale = 0f;
    botonPausa.SetActive(false);
    menuPausa.SetActive(true);
   
  


   }

   public void Reanudar(){
   Time.timeScale = 1f;                                                                          
   botonPausa.SetActive(true);
   menuPausa.SetActive(false);
   
  
   }

   public void Reinciar(){
  
  
  CargarPrefsReinicio();

 menuPausa.SetActive(false);
 botonPausa.SetActive(true);
 
  Time.timeScale = 1f;       
   
   }




   public void MenuSalir(){
 SceneManager.LoadScene("MenuPrincipal");

   }

// manejo de datos




// Método para guardar la partida con el email del usuario como clave
public void GuardarPartida(string emailUser, string passwordUser, int puntosUsuario, int vidaUsuario, float posicionUsuarioX, float posicionUsuarioY)
{
    // Crea una nueva instancia de UserPass con los datos de la partida
    UserPass userData = new UserPass
    {
         emailUser = emailUser,
        
        passwordUser = passwordUser,
        puntosUser = puntosUsuario,
        vidaUser = vidaUsuario,
        posNX = posicionUsuarioX,
        posNY = posicionUsuarioY
    };

    // Llama al método SaveData de DataManager para guardar los datos
    DataManager.instance.SaveData(userData);
}


         public void SendExistLogData()
    {
        SetearDatosGuardar();
            Debug.Log("Prefs Seteados Menu Pausa");
        string email = emailJaguPrefs;
        string password = passwordJaguPrefs;
         int vidaUserNew = vidaJaguPrefs;
        int puntosUserNew = puntosJaguPrefs;
        float posicionNX = posXJaguPrefs;
        float posicionNY = posYJaguPrefs;

        UserPass loginUser = new UserPass
        {
            emailUser = emailJaguPrefs,
            passwordUser = passwordJaguPrefs,
            puntosUser = puntosJaguPrefs,
            vidaUser = vidaJaguPrefs,
            posNX = posXJaguPrefs,
            posNY = posYJaguPrefs
        };

        RestClient.Put<UserPass>(BASE_URL + "Users/" + email.Replace(".", "_") + ".json", loginUser).Then(response =>
        {  
            Debug.Log("Datos Guardados en MenuPausa");

        }).Catch(err =>
        {
            Debug.LogError("Error Guardando en menu pausa: " + err.Message);
        });
    }

public void CargarPrefsReinicio(){
    

     Time.timeScale = 0f;  


    vidaJaguPrefs = PlayerPrefs.GetInt("VidaGuardar");
    Debug.Log("vida reinicio seteada: " + vidaJaguPrefs);
    puntosJaguPrefs = PlayerPrefs.GetInt("PuntosGuardar");
    Debug.Log("puntos rienicio seteados: " + puntosJaguPrefs);
    posXJaguPrefs = PlayerPrefs.GetFloat("PosicionX");
    Debug.Log("posX seteada: " + posXJaguPrefs);
    posYJaguPrefs = PlayerPrefs.GetFloat("PosicionY");
    Debug.Log("posY seteada: " + posYJaguPrefs);


SeteardatosReinicio();



 Time.timeScale = 1f;  

}

public void SeteardatosReinicio(){
      
    combateJugador = FindObjectOfType<CombateJugador>();
     puntaje = FindObjectOfType<Puntaje>();
     posicionJagu= FindObjectOfType<PosicionJagu>();
    combateJugador.SetearVida(vidaJaguPrefs);
     puntaje.SetearPuntaje(puntosJaguPrefs );
     posicionJagu.SetPositionX(posXJaguPrefs);
     posicionJagu.SetPositionY(posYJaguPrefs);
combateJugador.ActualizarBarraDeVidaInicioReincio(vidaJaguPrefs);
 Debug.Log("Datos PLayer Seteados Menu Pausa" );





}

public void ObtenerDatosUser (){
    emailJaguPrefs = PlayerPrefs.GetString("EmailGuardar");
    passwordJaguPrefs= PlayerPrefs.GetString("PasswordGuardar");
    vidaJaguPrefs= combateJugador.ObtenerVida();
    puntosJaguPrefs=puntaje.ObtenerPuntuacionUser();
    posXJaguPrefs=posicionJagu.ObtenerPosicionUserX();
    posYJaguPrefs=posicionJagu.ObtenerPosicionUserY();
  
}

public void SetearDatosGuardar(){
    ObtenerDatosUser ();
  PlayerPrefs.SetInt("VidaGuardar",vidaJaguPrefs);
  PlayerPrefs.SetInt("PuntosGuardar",puntosJaguPrefs);
  PlayerPrefs.SetFloat("PosicionX",posXJaguPrefs);
  PlayerPrefs.SetFloat("PosicionY",posYJaguPrefs);
  Debug.Log("Variables Menu pausa: " + emailJaguPrefs + " " + passwordJaguPrefs + " " + vidaJaguPrefs + " " + puntosJaguPrefs + " " + posXJaguPrefs + " " + posYJaguPrefs);

 panelGuardadoExitoso.SetActive(true);

}

public void CerrarBtnAceptar(){

 panelGuardadoExitoso.SetActive(false);
 menuPausa.SetActive(false);
  botonPausa.SetActive(true);
Time.timeScale = 1f;         


}
 
 




}
 

