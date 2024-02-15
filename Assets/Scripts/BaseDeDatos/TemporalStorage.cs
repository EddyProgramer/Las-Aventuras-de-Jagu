

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

   


    // Referencias a otras clases
      public CombateJugador combateJugador;
    public Puntaje puntaje;
   
     public PosicionJagu posicionJagu;
    public MenuPausa menuPausa;

    // Referencia al DataManager
    public DataManager dataManager;
    //Referencia a posicion Jagu
   

    private void Start()

    
    {


      
             
       //userIdTemp = PlayerPrefs.GetString("userIdTemp", "");




    }

   

    // Método para generar un nuevo userIdTemp
    public void GenerarUserIdTemp()
    {

       
        userIdTemp = Guid.NewGuid().ToString();
        Debug.Log("Nuevo userIdTemp generado: " + userIdTemp);
          // Guardar userIdTemp en el almacenamiento local del navegador
    PreviewLabs.PlayerPrefs.SetString("userIdTemp", userIdTemp);
    PreviewLabs.PlayerPrefs.Flush(); // Guardar los cambios
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
        //SetearPlayerPrefs();
    }


/*public void SetearPlayerPrefs(){

       vidaUsuarioPrefs = combateJugador.ObtenerVidaUser();
        puntosUsuarioPrefs = puntaje.ObtenerPuntuacionUser();
        posicionUsuarioXPrefs = posicionJagu.ObtenerPosicionUserX();
         posicionUsuarioYPrefs = posicionJagu.ObtenerPosicionUserY();
    
       PreviewLabs.PlayerPrefs.SetInt("VidaGuardar", vidaUsuarioPrefs);
        Debug.Log("vida cargada al playerprefs"+vidaUsuarioPrefs);
        PreviewLabs.PlayerPrefs.SetInt("PuntosGuardar", puntosUsuarioPrefs);
        Debug.Log("puntos cargados al playerprefs"+puntosUsuarioPrefs);
        PreviewLabs.PlayerPrefs.SetFloat("PosicionX", posicionUsuarioXPrefs);
       Debug.Log("posicion X cargado al playerprefs"+posicionUsuarioYPrefs);
        PlayerPrefs.SetFloat("posicionY", posicionUsuarioXPrefs);
         PreviewLabs.PlayerPrefs.SetFloat("PosicionY", posicionUsuarioYPrefs);
         Debug.Log("posicion X cargado al playerprefs"+posicionUsuarioYPrefs);
        PreviewLabs.PlayerPrefs.Flush();





}*/




 
 
}




    









