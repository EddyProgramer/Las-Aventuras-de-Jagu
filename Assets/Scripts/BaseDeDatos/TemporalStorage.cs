

// PRUEBA PARA QUE SE COMPRUEBE SI EXISTE UN IdUser generado en la base de datos


using UnityEngine;
using System;

public class TemporalStorage : MonoBehaviour
{
    // Variables para enviar a menú pausa
    public string userIdTemp;
    public int puntosUsuarioTemp;
    public int vidaUsuarioTemp;
// variable para obtener la posicion del usuario
    public float posicionUsuarioTempX;
    public float posicionUsuarioTempY;

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
        puntaje = GetComponent<Puntaje>();
        combateJugador = GetComponent<CombateJugador>();
        menuPausa = GetComponent<MenuPausa>();
        dataManager = GetComponent<DataManager>();
        posicionJagu= GetComponent<PosicionJagu>();

         // Cargar userIdTemp desde el almacenamiento local del navegador
             
        userIdTemp = PlayerPrefs.GetString("userIdTemp", "");


        // Obtener la referencia al DataManager
        dataManager = FindObjectOfType<DataManager>();

        // Verificar si ya existe un userIdTemp en la base de datos
        VerificarUserIdExistente();
    }

    // Método para verificar si ya existe un userIdTemp en la base de datos
    private void VerificarUserIdExistente()
    {

         // Verificar si existe el userIdTemp en PlayerPrefs
    if (PlayerPrefs.HasKey("userIdTemp"))
    {
        string loadedUser = PlayerPrefs.GetString("userIdTemp");
        Debug.Log("Usuario encontrado en la base de datos. ID: " + loadedUser);
    }
    else
    {
        Debug.Log("No se encontró el usuario en PlayerPrefs. Generando nuevo userIdTemp...");
        // Si el usuario no existe, generar un nuevo userIdTemp
        GenerarUserIdTemp();
    }
        
    }

    // Método para generar un nuevo userIdTemp
    private void GenerarUserIdTemp()
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
        puntosUsuarioTemp = puntaje.ObtenerPuntuacionUser();
        vidaUsuarioTemp = combateJugador.ObtenerVidaUser();
        posicionUsuarioTempX = posicionJagu.ObtenerPosicionUserX();
         posicionUsuarioTempY = posicionJagu.ObtenerPosicionUserY();
        // Enviar los datos al menú pausa
        menuPausa.GuardarPartida(userIdTemp, puntosUsuarioTemp, vidaUsuarioTemp,posicionUsuarioTempX,posicionUsuarioTempY);
        
        Debug.Log ("Datos enviados a menupausa");
    }
}




    









