


      

/*using UnityEngine;
using System;

public class TemporalStorage : MonoBehaviour
{
    // Variables para enviar a menú pausa
    public string userIdTemp;
    public int puntosUsuarioTemp;
    public int vidaUsuarioTemp;

    // Referencias a otras clases
    public Puntaje puntaje;
    public CombateJugador combateJugador;
    public MenuPausa menuPausa;

    private void Start()
    {
        // Obtener las referencias a las clases
        puntaje = GetComponent<Puntaje>();
        combateJugador = GetComponent<CombateJugador>();
        menuPausa = GetComponent<MenuPausa>();

        // Generar un userIdTemp único al inicio
        userIdTemp = Guid.NewGuid().ToString();
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

        // Obtener los datos
        puntosUsuarioTemp = puntaje.ObtenerPuntuacionUser();
        vidaUsuarioTemp = combateJugador.ObtenerVidaUser();
        
        // Enviar los datos al menú pausa
        menuPausa.GuardarPartida(userIdTemp, puntosUsuarioTemp, vidaUsuarioTemp);
        
        Debug.Log ("Datos enviados a menupausa");
    }
}*/







// PRUEBA PARA QUE SE COMPRUEBE SI EXISTE UN IdUser generado en la base de datos


using UnityEngine;
using System;

public class TemporalStorage : MonoBehaviour
{
    // Variables para enviar a menú pausa
    public string userIdTemp;
    public int puntosUsuarioTemp;
    public int vidaUsuarioTemp;

    // Referencias a otras clases
    public Puntaje puntaje;
    public CombateJugador combateJugador;
    public MenuPausa menuPausa;

    // Referencia al DataManager
    public DataManager dataManager;

    private void Start()

    
    {


           // Obtener las referencias a las clases
        puntaje = GetComponent<Puntaje>();
        combateJugador = GetComponent<CombateJugador>();
        menuPausa = GetComponent<MenuPausa>();
        dataManager = GetComponent<DataManager>();


        // Obtener la referencia al DataManager
        dataManager = FindObjectOfType<DataManager>();

        // Verificar si ya existe un userIdTemp en la base de datos
        VerificarUserIdExistente();
    }

    // Método para verificar si ya existe un userIdTemp en la base de datos
    private void VerificarUserIdExistente()
    {

         GenerarUserIdTemp();
        // Realizar la carga de datos utilizando el userIdTemp actual
        dataManager.LoadData(userIdTemp, (loadedUser) =>
        {
            if (loadedUser != null)
            {
                Debug.Log("Usuario encontrado en la base de datos. ID: " + loadedUser);
            }
            else
            {
                Debug.Log("No se encontró el usuario en la base de datos. Generando nuevo userIdTemp...");
                // Si el usuario no existe, generar un nuevo userIdTemp
                    GenerarUserIdTemp();
            }
        });
    }

    // Método para generar un nuevo userIdTemp
    private void GenerarUserIdTemp()
    {
        userIdTemp = Guid.NewGuid().ToString();
        Debug.Log("Nuevo userIdTemp generado: " + userIdTemp);
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

        // Obtener los datos
        puntosUsuarioTemp = puntaje.ObtenerPuntuacionUser();
        vidaUsuarioTemp = combateJugador.ObtenerVidaUser();
        
        // Enviar los datos al menú pausa
        menuPausa.GuardarPartida(userIdTemp, puntosUsuarioTemp, vidaUsuarioTemp);
        
        Debug.Log ("Datos enviados a menupausa");
    }
}




    









