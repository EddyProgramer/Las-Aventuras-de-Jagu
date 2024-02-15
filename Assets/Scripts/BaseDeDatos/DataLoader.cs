
using UnityEngine;
using UnityEngine.SceneManagement;


public class DataLoader : MonoBehaviour
{

    
    
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
  
            Debug.Log("Escena cargada: " + scene.name);
            
        


    }

   
}
