
using UnityEngine;
using UnityEngine.SceneManagement;


public class DataLoader : MonoBehaviour
{


     public GameObject DatosCargadosExitosamente;
    private void Awake()
    {
      
       
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

  private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
         
          Time.timeScale = 0f;
          DatosCargadosExitosamente.SetActive(false);
          Debug.Log("DatosCargadosExitosamente oculto");
          BorrarPlayerPrefs();
           Debug.Log("Playerprefs borrados Data Loader");
            
            Debug.Log("Escena cargada: " + scene.name);
            
        


    }

    public void BorrarPlayerPrefs(){
         // Borrar una clave específica de PlayerPrefs
     string vidaBorrar = "VidaGuardar";
     PlayerPrefs.DeleteKey(vidaBorrar); 
       string puntosBorrar = "PuntosGuardar";
     PlayerPrefs.DeleteKey(puntosBorrar); 
       string posXBorrar = "PosicionX";
     PlayerPrefs.DeleteKey(posXBorrar); 
     string posYBorrar = "PosicionY";
     PlayerPrefs.DeleteKey(posYBorrar); 




     }
}
