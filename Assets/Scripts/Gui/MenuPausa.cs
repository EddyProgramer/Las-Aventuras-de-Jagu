
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPausa : MonoBehaviour
{

    public DataManager dataManager;

    [SerializeField] private GameObject botonPausa;

    [SerializeField] private GameObject menuPausa;
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

    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

// manejo de datos


/*public void GuardarPartida(){
        // Llamar al método CreateAndSaveUser() desde UserManager
        UserManager userManager = FindObjectOfType<UserManager>(); // Encuentra la instancia de UserManager en la escena
        if (userManager != null)
        {
            // Llamar al método y pasar los datos del usuario
            userManager.CreateAndSaveUser(50, 100,26);
        }
        else
        {
            Debug.LogError("UserManager not found in the scene!");
        }
    }*/





//CODIGO PARA PODER PASAR LOS PARAMETROS DESDE DIFERENTES CLASES 

/*public void GuardarPartida(int userIdd, int userScore, int userLive) {
    UserManager userManager = FindObjectOfType<UserManager>(); 
    if (userManager != null) {
        userManager.CreateAndSaveUser(userIdd, userScore, userLive);
    } else {
        Debug.LogError("UserManager not found in the scene!");
    }
}*/



//SEGUNDA PRUEBA DE CODIGO




    // Método para guardar la partida con userId y/o userScore
    public void GuardarPartida(int userId, int puntosUsuario, int vidaUsuario ) {
        // Encuentra la instancia de UserManager en la escena
        UserManager userManager = FindObjectOfType<UserManager>(); 
        if (userManager != null) {
            // Llama al método y pasa los datos de la partida
            
                userManager.CreateAndSaveUser(userId, puntosUsuario, vidaUsuario);
           
                
            }
         else {
            Debug.LogError("UserManager not found in the scene!");
        }
    }









 
   }
 

