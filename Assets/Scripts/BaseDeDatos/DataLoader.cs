
using UnityEngine;
using UnityEngine.SceneManagement;


public class DataLoader : MonoBehaviour
{

     int vidaSeteador;

     int puntajeSeteador;

     float posicionSeteadorX;
      float posicionSeteadorY;
    // Referencias a otras clases
    public Puntaje puntaje;
    public CombateJugador combateJugador;

    public PosicionJagu posicionJagu;

    public BarraDeVida barraDeVida;

  
    
    private void Awake()
    {
         // Obtener las referencias a las clases
     
        puntaje = FindObjectOfType<Puntaje>();
        combateJugador = FindObjectOfType<CombateJugador>();
        posicionJagu = FindObjectOfType<PosicionJagu>();
        barraDeVida = FindObjectOfType<BarraDeVida>();
       
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

  private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
 
          Time.timeScale = 0f;
  
            Debug.Log("Escena cargada: " + scene.name);

           
        // Este método se ejecutará cada vez que se cargue una escena
    /*  
        
         // Setear vida y barra de vida
        combateJugador = FindObjectOfType<CombateJugador>();
      vidaSeteador = PreviewLabs.PlayerPrefs.GetInt("VidaGuardada",vidaSeteador);
      combateJugador.SetearVida(vidaSeteador);
      
      Debug.Log("vida seteada: " + vidaSeteador);
      barraDeVida = FindObjectOfType<BarraDeVida>();  
       barraDeVida.SetearBarraVida(vidaSeteador);
          Debug.Log("Barra vida Seteada: " + vidaSeteador);


            // Setear Puntaje
        puntaje = FindObjectOfType<Puntaje>();
        puntajeSeteador = PreviewLabs.PlayerPrefs.GetInt("PuntosGuardados",puntajeSeteador);
        puntaje.SetearPuntaje(puntajeSeteador);
          Debug.Log("puntaje seteado: " + puntajeSeteador);


   // Setear Posicion X
        posicionJagu = FindObjectOfType<PosicionJagu>();
        posicionSeteadorX = PreviewLabs.PlayerPrefs.GetFloat("posicionX",posicionSeteadorX);
        posicionJagu.SetPositionX(posicionSeteadorX);
          Debug.Log("posicion X seteada: " + posicionSeteadorX);

   // Setear Posicion Y
        posicionJagu = FindObjectOfType<PosicionJagu>();
        posicionSeteadorY = PreviewLabs.PlayerPrefs.GetFloat("posicionY",posicionSeteadorY);
        posicionJagu.SetPositionY(posicionSeteadorY);
          Debug.Log("posicion Y seteada: " + posicionSeteadorY);*/






    }

   
}
