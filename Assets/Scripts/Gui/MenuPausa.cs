
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




    // Método para guardar la partida con userId y/o userScore
    public void GuardarPartida(string userId, int puntosUsuario, int vidaUsuario ) {
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
 

