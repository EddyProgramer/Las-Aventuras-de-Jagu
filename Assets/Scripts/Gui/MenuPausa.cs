
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Proyecto26;

public class MenuPausa : MonoBehaviour
{

  private const string BASE_URL = "https://fir-unity-c9e15-default-rtdb.firebaseio.com/"; // URL base de Firebase
     public int vidaPrefs1;
      public int puntosPrefs1;
      public float posXprefs1;
       public float posYprefs1;


      public string emailJaguPrefs;
      public string passwordJaguPrefs;
       public int vidaJaguPrefs;
       public int puntosJaguPrefs;
       public float posXJaguPrefs;
        public float posYJaguPrefs;

        //public string emailUser;
      
    public DataManager dataManager;
    public TemporalStorage temporalStorage;
     //private GameManager gameManager;

    [SerializeField] private GameObject botonPausa;

    [SerializeField] private GameObject menuPausa;

     public CombateJugador combateJugador;
    public Puntaje puntaje;
   
     public PosicionJagu posicionJagu;
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
  // StartCoroutine(EsperarCargaDatos1());
  //CargarPrefsReinicio();
 Debug.Log("Boton reiniciar presionado");
 // GameManager.Instance.CargarDatosBD();
  Time.timeScale = 1f;       
   
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
       combateJugador = GetComponent<CombateJugador>();
        combateJugador = FindObjectOfType<CombateJugador>();
        puntaje = FindObjectOfType<Puntaje>();
        posicionJagu= FindObjectOfType<PosicionJagu>();








    vidaPrefs1 = PlayerPrefs.GetInt("VidaGuardar");
    Debug.Log("vida reinicio seteada: " + vidaPrefs1);
    puntosPrefs1 = PlayerPrefs.GetInt("PuntosGuardados");
    Debug.Log("puntos rienicio seteados: " + puntosPrefs1);
    posXprefs1 = PlayerPrefs.GetFloat("posicionX");
    Debug.Log("posX seteada: " + posXprefs1);
    posYprefs1 = PlayerPrefs.GetFloat("posicionY");
    Debug.Log("posY seteada: " + posYprefs1);

     combateJugador.SetearVida(vidaPrefs1);
     puntaje.SetearPuntaje(puntosPrefs1 );
     posicionJagu.SetPositionX(posXprefs1);
     posicionJagu.SetPositionY(posYprefs1);
     combateJugador.ObtenerVida();
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
  // PlayerPrefs.SetString("EmailGuardar",emailJaguPrefs);
  // PlayerPrefs.SetString("PasswordGuardar",passwordJaguPrefs);
  PlayerPrefs.SetInt("VidaGuardar",vidaJaguPrefs);
  PlayerPrefs.SetInt("PuntosGuardar",puntosJaguPrefs);
 PlayerPrefs.SetFloat("PosicionX",posXJaguPrefs);
  PlayerPrefs.SetFloat("PosicionY",posYJaguPrefs);
  Debug.Log("Variables Menu pausa: " + emailJaguPrefs + " " + passwordJaguPrefs + " " + vidaJaguPrefs + " " + puntosJaguPrefs + " " + posXJaguPrefs + " " + posYJaguPrefs);



}


 /* public void BorrarPlayerPrefs(){
         // Borrar una clave específica de PlayerPrefs
     string vidaBorrar = "VidaGuardar";
     PlayerPrefs.DeleteKey(vidaBorrar); 
       string puntosBorrar = "PuntosGuardar";
     PlayerPrefs.DeleteKey(puntosBorrar); 
       string posXBorrar = "PosicionX";
     PlayerPrefs.DeleteKey(posXBorrar); 
     string posYBorrar = "PosicionY";
     PlayerPrefs.DeleteKey(posYBorrar); 




     }*/

}
 

