
using UnityEngine;

using System.Collections;
public class MenuPausa : MonoBehaviour
{
     public int vidaPrefs1;
      public int puntosPrefs1;
      public float posXprefs1;
       public float posYprefs1;
    public DataManager dataManager;
    public TemporalStorage temporalStorage;

    [SerializeField] private GameObject botonPausa;

    [SerializeField] private GameObject menuPausa;

     public CombateJugador combateJugador;
    public Puntaje puntaje;
   
     public PosicionJagu posicionJagu;
   public void Pausa(){
    //Time.timeScale = 0f;
    botonPausa.SetActive(false);
    menuPausa.SetActive(true);
   }

   public void Reanudar(){
   Time.timeScale = 1f;                                                                          
        botonPausa.SetActive(true);
    menuPausa.SetActive(false);
   }

   public void Reinciar(){
   StartCoroutine(EsperarCargaDatos1());
 Debug.Log("Boton reiniciar presionado");
   
   }

// manejo de datos
 IEnumerator EsperarCargaDatos1()
    {
       Debug.Log("Iniciando carga de datos...");
        CargarPrefsReinicio();
        // Llama al método para cargar los datos de la base de datos
        Debug.Log("Esperando a que los datos se carguen...");
        while (!DatosCargadosCompletamente1())
        {
            yield return null;
            
        }

        // Cuando los datos se hayan cargado completamente, continúa con el resto del código
         Time.timeScale = 1f;
    menuPausa.SetActive(false);
    botonPausa.SetActive(true);

    Debug.Log("Datos Cargados Continuando...");
    }
    
 bool DatosCargadosCompletamente1()
    {

        return vidaPrefs1 != 0 && puntosPrefs1 >= 0 && posXprefs1 != 0 && posYprefs1 != 0;
    }



    // Método para guardar la partida con userId y/o userScore
    public void GuardarPartida(string userId, int puntosUsuario, int vidaUsuario, float posicionUsuarioX, float posicionUsuarioY ) {
        // Encuentra la instancia de UserManager en la escena
        UserManager userManager = FindObjectOfType<UserManager>(); 
        if (userManager != null) {
            // Llama al método y pasa los datos de la partida
            
                userManager.CreateAndSaveUser(userId, puntosUsuario, vidaUsuario,posicionUsuarioX,posicionUsuarioY);
           
                
            }
         else {
            Debug.LogError("UserManager not found in the scene!");
        }
        temporalStorage= FindObjectOfType<TemporalStorage>();

        temporalStorage.SetearPlayerPrefs();
        Debug.Log("prefs setados temporal Storage");
    }

    
public void CargarPrefsReinicio(){
       combateJugador = GetComponent<CombateJugador>();
        combateJugador = FindObjectOfType<CombateJugador>();
        puntaje = FindObjectOfType<Puntaje>();
        posicionJagu= FindObjectOfType<PosicionJagu>();


temporalStorage= FindObjectOfType<TemporalStorage>();





    vidaPrefs1 = PreviewLabs.PlayerPrefs.GetInt("VidaGuardar");
    Debug.Log("vida reinicio seteada: " + vidaPrefs1);
    puntosPrefs1 = PreviewLabs.PlayerPrefs.GetInt("PuntosGuardados");
    Debug.Log("puntos rienicio seteados: " + puntosPrefs1);
    posXprefs1 = PreviewLabs.PlayerPrefs.GetFloat("posicionX");
    Debug.Log("posX seteada: " + posXprefs1);
    posYprefs1 = PreviewLabs.PlayerPrefs.GetFloat("posicionY");
    Debug.Log("posY seteada: " + posYprefs1);

    combateJugador.SetearVida(vidaPrefs1);
    puntaje.SetearPuntaje(puntosPrefs1 );
     posicionJagu.SetPositionX(posXprefs1);
     posicionJagu.SetPositionY(posYprefs1);
}


}
 

