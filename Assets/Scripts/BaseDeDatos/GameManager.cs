using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int vida;

    public int puntos;

    public float posX;
    public float posY;
  public Vector2 posicionJugador;

 // Referencias a otras clases
    public Puntaje puntaje;
    public CombateJugador combateJugador;

    public PosicionJagu posicionJagu;
    
  


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
      
      
    }
    

    public void GuardarDatos()
    {
             
         
          ObtenerPlayerPrefs();

        PreviewLabs.PlayerPrefs.SetInt("VidaGuardar", vida);
        Debug.Log("vida cargada al playerprefs"+vida);
        PreviewLabs.PlayerPrefs.SetInt("PuntosGuardados", puntos);
        Debug.Log("puntos cargados al playerprefs"+puntos);
        PreviewLabs.PlayerPrefs.SetFloat("posicionX", posicionJugador.x);
        PlayerPrefs.SetFloat("posicionY", posicionJugador.y);
         Debug.Log("posicion Player cargado al playerprefs"+posicionJugador);
        PreviewLabs.PlayerPrefs.Flush();

      

    }

    public void ObtenerPlayerPrefs(){

 
          vida = PreviewLabs.PlayerPrefs.GetInt("VidaGuardada",100); // Valor por defecto de vida es 100 si no se encuentra guardado
         

           Debug.Log("vidaObtenida: " + vida);
           
         puntos = PreviewLabs.PlayerPrefs.GetInt("PuntosGuardados",0); // Valor por defecto de puntos es 0 si no se encuentra guardado
         
       
         Debug.Log("puntos obtenidos: " + puntos);
         posX = PreviewLabs.PlayerPrefs.GetFloat("posicionX",3); // Valor por defecto de posición X es 0 si no se encuentra guardado

   
         Debug.Log("posX obtenida: " + posX);
        
         posY = PreviewLabs.PlayerPrefs.GetFloat("posicionY",2); // Valor por defecto de posición Y es 0 si no se encuentra guardado

     Debug.Log("posY obtenida: " + posY);

      
      posicionJugador = new Vector2(posX, posY);



     }

    
   
}
