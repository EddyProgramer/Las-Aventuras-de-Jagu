
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour
{



    [SerializeField] public GameObject menuMuerte;

   public CombateJugador combateJugador;
    public Puntaje puntaje;
   
     public PosicionJagu posicionJagu;
     public MenuPausa menuPausa;

  public int vidaJprefsMuerte;
  public int puntosJPrefsMuerte;
  public float posXJPrefsMuerte;
  public float posYJPrefsMuerte;
   
   public void Reiniciar(){

   

CargarPrefsReinicioMuerte();
combateJugador.ActivarSonidoFondo();
        Time.timeScale = 1f;  
       menuMuerte.SetActive(false);

   }

   public void Cerrar (){

        SceneManager.LoadScene("MenuPrincipal");
  
   }



   public void CargarPrefsReinicioMuerte(){
    

     //Time.timeScale = 0f;  


    vidaJprefsMuerte = PlayerPrefs.GetInt("VidaGuardar");
    Debug.Log("vida reinicio Muerte seteada: " + vidaJprefsMuerte);
    puntosJPrefsMuerte = PlayerPrefs.GetInt("PuntosGuardar");
    Debug.Log("puntos reinicio Muerte seteados: " + puntosJPrefsMuerte);
    posXJPrefsMuerte = PlayerPrefs.GetFloat("PosicionX");
    Debug.Log("posX Muerte seteada: " + posXJPrefsMuerte);
    posYJPrefsMuerte = PlayerPrefs.GetFloat("PosicionY");
    Debug.Log("posY Muerte seteada: " + posYJPrefsMuerte);


SeteardatosReinicioMuerte();
 

 //Time.timeScale = 1f;  

}

public void SeteardatosReinicioMuerte(){
      
    combateJugador = FindObjectOfType<CombateJugador>();
     puntaje = FindObjectOfType<Puntaje>();
     posicionJagu= FindObjectOfType<PosicionJagu>();
    combateJugador.SetearVida(vidaJprefsMuerte);
     puntaje.SetearPuntaje(puntosJPrefsMuerte);
     posicionJagu.SetPositionX(posXJPrefsMuerte);
     posicionJagu.SetPositionY(posYJPrefsMuerte);
combateJugador.ActualizarBarraDeVidaInicioReincio(vidaJprefsMuerte);
 Debug.Log("Datos PLayer Seteados Menu Muerte" );





}
 }

