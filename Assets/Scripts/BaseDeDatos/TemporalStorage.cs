
using UnityEngine;

public class TemporalStorage : MonoBehaviour
{
    // variables para enviar a menu pausa
     // userId, puntosUsuario, vidaUsuario
       public int userIdTemp=1725502718;
       public int puntosUsuarioTemp;
       public int vidaUsuarioTemp;

     

 
       
         
     public  Puntaje puntaje;     // referencia a clase puntaje
      public  CombateJugador combateJugador;     // referencia a clase combatejugador

      public MenuPausa menuPausa;  // referencia a clase menupausa

 private void Start()
    {
        puntaje = GetComponent<Puntaje>(); // Obtener la referencia a la puntaje
        combateJugador = GetComponent<CombateJugador>(); // Obtener la referencia a la clase combatejugador
        menuPausa = GetComponent<MenuPausa>(); // Obtener la referencia a la clase menu pausa
       
       puntosUsuarioTemp=60;
       vidaUsuarioTemp=93;
       
        
        
      
       
    }
       
        /*private void Update(){

         if (puntaje == null)
        {
            Debug.LogError("Puntaje no encontrada en el mismo GameObject.");
        }


               else{

               puntaje.ObtenerPuntuacionUser();
               Debug.Log("PuntuacionEnAlmacenTemporal");
              }


        if (combateJugador == null)
        {
            Debug.LogError("CombataJugador no encontrada en el mismo GameObject.");
        }


               else{

               combateJugador.ObtenerVidaUser();
               Debug.Log("PuntuacionEnAlmacenTemporal");
                 }
          


        }*/
        

          

          public   void EnviarDatosMenuPausa(){
              
                      MenuPausa menuPausa = FindObjectOfType<MenuPausa>(); 
                 menuPausa.GuardarPartida(userIdTemp,puntosUsuarioTemp,vidaUsuarioTemp);
               Debug.Log ("Datos enviados a menupausa");

             }
           

 
       
          
           
        }
    









