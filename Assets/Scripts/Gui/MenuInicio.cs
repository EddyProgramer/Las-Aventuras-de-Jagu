using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
 
    public GameManager gameManager;
     

    private void Start()
    {
      
       // gameManager = FindObjectOfType<GameManager>();

       
       
       
    //    VerificarEstadoUser();
    }

  /*  public void VerificarEstadoUser()
    {
        if (PlayerPrefs.HasKey("userIdTemp"))
        {
            string loadedUser = PlayerPrefs.GetString("userIdTemp");
            Debug.Log("Usuario encontrado en PlayerPrefs: " + loadedUser);
         
             if (gameManager != null)
        {

            gameManager.GuardarDatos();
        }
      
        }
        else
        {
            Debug.Log("No se encontró el usuario en PlayerPrefs. Iniciando Nuevo Juego...");
            
            gameManager.ObtenerPlayerPrefs();
            Debug.Log("se iniciara un nuevo juego...");
        }
    }*/

    




      public void CargarNivel()
    {
       
       SceneManager.LoadScene("Nivel1");

    }


}
