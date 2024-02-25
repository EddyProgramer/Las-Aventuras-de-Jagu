using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
 

     

    private void Start()
    {
      
     
    }

  public void SalirDeLaAplicacion()
    {
    #if UNITY_STANDALONE
        // Salir de la aplicación en build para escritorio
        Application.Quit();
        Debug.Log("se ha cerrado el juego");

    #elif UNITY_WEBGL
        // Salir de la aplicación en build WebGL
        // Este método no está soportado en WebGL debido a restricciones de seguridad
        // Puedes redirigir al usuario a otra página o realizar alguna otra acción en su lugar
        Debug.Log("Salir de la aplicación en WebGL no es soportado");
    #endif
    }


      public void CargarNivel()
    {
       
       SceneManager.LoadScene("Nivel1");

    }

        public void CargarIntro()
    {
       
       SceneManager.LoadScene("Intro");

    }

    


}
