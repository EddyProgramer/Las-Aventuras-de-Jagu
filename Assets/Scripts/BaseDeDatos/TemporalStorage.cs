

// PRUEBA PARA QUE SE COMPRUEBE SI EXISTE UN IdUser generado en la base de datos


using UnityEngine;
using System;

public class TemporalStorage : MonoBehaviour
{
    // Variables para enviar a menú pausa
    
    public string userId;
    public string userIdTemp;
     public int puntosUsuarioTemp;
    public int vidaUsuarioTemp;
// variable para obtener la posicion del usuario
    public float posicionUsuarioTempX;
    public float posicionUsuarioTempY;
// vairables para guardar player prefs
    public string userIdPrefs;
        public int vidaUsuarioPrefs;
     public int puntosUsuarioPrefs;
 
// variable para obtener la posicion del usuario
    public float posicionUsuarioXPrefs;
    public float posicionUsuarioYPrefs;

      public int vidaReinicioPrefs;
     public int puntosReinicioPrefs;
 
// variable para obtener la posicion del usuario
    public float posicionReinicioXPrefs;
    public float posicionReinicioYPrefs;

    // Referencias a otras clases
    public Puntaje puntaje;
    public CombateJugador combateJugador;
    public MenuPausa menuPausa;

    // Referencia al DataManager
    public DataManager dataManager;
    //Referencia a posicion Jagu
    public PosicionJagu posicionJagu;

    private void Start()

    
    {


           // Obtener las referencias a las clases
      /*  puntaje = GetComponent<Puntaje>();
        combateJugador = GetComponent<CombateJugador>();
        menuPausa = GetComponent<MenuPausa>();
        dataManager = GetComponent<DataManager>();
        posicionJagu= GetComponent<PosicionJagu>();*/

         // Cargar userIdTemp desde el almacenamiento local del navegador
             
        userIdTemp = PlayerPrefs.GetString("userIdTemp", "");




    }

   

    // Método para generar un nuevo userIdTemp
    public void GenerarUserIdTemp()
    {
        userIdTemp = Guid.NewGuid().ToString();
        Debug.Log("Nuevo userIdTemp generado: " + userIdTemp);
          // Guardar userIdTemp en el almacenamiento local del navegador
    PlayerPrefs.SetString("userIdTemp", userIdTemp);
    PlayerPrefs.Save(); // Guardar los cambios
    Debug.Log("userIdTempGuadadoPlayerPrefs: " + userIdTemp);

    }

    public void EnviarDatosMenuPausa()
    {
        // Obtener las instancias de las clases si es necesario
        if (menuPausa == null)
            menuPausa = FindObjectOfType<MenuPausa>(); 
        if (puntaje == null)
            puntaje = FindObjectOfType<Puntaje>(); 
        if (combateJugador == null)
            combateJugador = FindObjectOfType<CombateJugador>(); 
        if (posicionJagu == null)
            posicionJagu = FindObjectOfType<PosicionJagu>(); 

        // Obtener los datos
        vidaUsuarioTemp = combateJugador.ObtenerVidaUser();
        puntosUsuarioTemp = puntaje.ObtenerPuntuacionUser();
        posicionUsuarioTempX = posicionJagu.ObtenerPosicionUserX();
         posicionUsuarioTempY = posicionJagu.ObtenerPosicionUserY();
        // Enviar los datos al menú pausa
        menuPausa.GuardarPartida(userIdTemp, puntosUsuarioTemp, vidaUsuarioTemp,posicionUsuarioTempX,posicionUsuarioTempY);
        
        Debug.Log ("Datos enviados a menupausa");
    }


public void SetearPlayerPrefs(){

       vidaUsuarioPrefs = combateJugador.ObtenerVidaUser();
        puntosUsuarioPrefs = puntaje.ObtenerPuntuacionUser();
        posicionUsuarioXPrefs = posicionJagu.ObtenerPosicionUserX();
         posicionUsuarioYPrefs = posicionJagu.ObtenerPosicionUserY();
    
       PreviewLabs.PlayerPrefs.SetInt("VidaGuardar", vidaUsuarioPrefs);
        Debug.Log("vida cargada al playerprefs"+vidaUsuarioPrefs);
        PreviewLabs.PlayerPrefs.SetInt("PuntosGuardados", puntosUsuarioPrefs);
        Debug.Log("puntos cargados al playerprefs"+puntosUsuarioPrefs);
        PreviewLabs.PlayerPrefs.SetFloat("posicionX", posicionUsuarioXPrefs);
        PlayerPrefs.SetFloat("posicionY", posicionUsuarioXPrefs);
         PreviewLabs.PlayerPrefs.SetFloat("posicionY", posicionUsuarioYPrefs);
         Debug.Log("posicion Player cargado al playerprefs"+posicionUsuarioYPrefs);
        PreviewLabs.PlayerPrefs.Flush();





}



public void CargarPrefsReinicio(){

    vidaReinicioPrefs = PreviewLabs.PlayerPrefs.GetInt("VidaGuardar");
    Debug.Log("vida reinicio seteada: " + vidaReinicioPrefs);
    puntosReinicioPrefs = PreviewLabs.PlayerPrefs.GetInt("PuntosGuardados");
    Debug.Log("puntos obtenidos: " + puntosReinicioPrefs);
    posicionReinicioXPrefs = PreviewLabs.PlayerPrefs.GetFloat("posicionX");
    Debug.Log("posX obtenida: " + posicionReinicioXPrefs);
    posicionReinicioYPrefs = PreviewLabs.PlayerPrefs.GetFloat("posicionY");
    Debug.Log("posY obtenida: " + posicionReinicioXPrefs);
    combateJugador.SetearVida(vidaReinicioPrefs);
    puntaje.SetearPuntaje(puntosReinicioPrefs);
     posicionJagu.SetPositionX(posicionReinicioXPrefs);
     posicionJagu.SetPositionY(posicionReinicioYPrefs);
}

 
 
}




    









